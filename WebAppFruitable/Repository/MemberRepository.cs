using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;
using WebAppFruitable.Services;

namespace WebAppFruitable.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(FruitableContext context) : base(context)
    {
    }

    public int Add(Member obj)
    {
        Context.Member.Add(obj);
        return Context.SaveChanges();
    }

    public async Task<Member?> Login(Member obj)
    {
        var member = await Context.Member.FirstOrDefaultAsync(m => m.Email == obj.Email && m.Password == obj.Password);
        if (member != null)
        {
            Context.Member.Update(member);
            await Context.SaveChangesAsync();
        }

        return member;
    }

    public async Task<string?> RequestPasswordResetAsync(string email)
    {
        var member = await Context.Member.FirstOrDefaultAsync(m => m.Email == email);
        if (member == null)
            return null;

        var resetToken = Helper.GeneratorToken();
        member.ResetToken = resetToken;
        member.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15);

        Context.Member.Update(member);
        await Context.SaveChangesAsync();

        return resetToken;
    }

    public async Task<int> ResetPasswordAsync(string email, string resetToken, string newPassword)
    {
        var member = await Context.Member.FirstOrDefaultAsync(m => m.Email == email);
        if (member == null)
            return -1;

        if (member.ResetToken != resetToken || member.ResetTokenExpiry < DateTime.UtcNow)
            return -1;

        var passwordHash = Helper.HashPassword(newPassword);
        member.Password = passwordHash;
        member.ResetToken = null;
        member.ResetTokenExpiry = null;
        member.UpdatedDate = DateTime.UtcNow;

        Context.Member.Update(member);
        return await Context.SaveChangesAsync();
    }

    public async Task<string> ForgotPasswordAsync(Member member)
    {
        var resetToken = Helper.GeneratorToken();
        member.ResetToken = resetToken;
        member.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15);
        member.UpdatedDate = DateTime.UtcNow;
        Context.Member.Update(member);
        await Context.SaveChangesAsync();
        return resetToken;
    }

    public async Task<int?> ResetForgotPasswordAsync(ResetForgotPassword obj)
    {
        var user = await Context.Member.FirstOrDefaultAsync(m =>
            m.ResetToken == obj.Token && m.ResetTokenExpiry > DateTime.UtcNow);
        if (user == null)
            return null;

        user.Password = Helper.HashPassword(obj.NewPassword);
        user.ResetToken = null;
        user.ResetTokenExpiry = null;
        user.UpdatedDate = DateTime.UtcNow;
        return await Context.SaveChangesAsync();
    }

    public async Task<Member?> GetMember(string email)
    {
        var member = await Context.Member.FirstOrDefaultAsync(m => m.Email == email);
        return member;
    }
}
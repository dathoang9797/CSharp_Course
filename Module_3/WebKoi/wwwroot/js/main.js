(function ($) {
    "use strict";

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/notify")
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");

            $("#btnRec").click(function () {
                console.log("click")
                new bootstrap.Modal("#recModal").show();
            })

            $("#frm").submit(function (ev) {
                ev.preventDefault();
                const obj = {
                    "fullname": $(frm['fullname']).val(),
                    "email": $(frm['email']).val(),
                    "phone": $(frm['phone']).val(),
                }
                $.post("/home/recommend", obj, (d) => {
                    console.log({d})
                })
            })

            $($("input[name='roleId']")[0]).prop("checked", true);
            $($("input[name='serviceId']")[0]).prop("checked", true);


            // $("#statusId").change(function () {
            //     window.location.href = `/invoice/select/${$(this).val()}`;
            // });
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    }

    connection.onclose(async () => {
        await start();
    });

    connection.on("receiveMsg", function (msg, obj) {
        console.log({msg, obj})
        $("#rs").append(`
         <tr>
            <td>${obj['fullName']}</td>
            <td>${obj['phone']}</td>
            <td>${obj['job']}</td>
            <td>${obj['roleId']}</td>
            <td>${obj['serviceId']}</td>
            <td>${obj['numberOfOrderId']}</td>
            <td>${obj['businessId']}</td>
            <td>${obj['description']}</td>
        </tr>
        `)

        $("#liveToast div.toast-body").text(msg);
        new bootstrap.Toast(liveToast).show();
    })


// Start the connection.
    start();
})(jQuery);


(function ($) {
    "use strict";

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");

            $(".info").click(function () {
                $("#info").text($(this).text());
                $(frm['userId']).val($(this).attr("val"));
            });

            $(frm).submit(function (e) {
                e.preventDefault();
                connection.invoke("SendMessageAsync", $(this['userId']).val(), $(this['msg']).val());
                $(this['msg']).val(null);
            });
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    }

    connection.onclose(async () => {
        await start();
    });

    connection.on("receiveMsg", function (obj) {
        console.log({obj})
        $("#rs").append(`
         <li>
            ${obj['sender']}: <span>${obj['msg']}</span>
        </li>
        `)

        $("#liveToast div.toast-body").text(msg);
        new bootstrap.Toast(liveToast).show();
    })

// Start the connection.
    start();
})(jQuery);


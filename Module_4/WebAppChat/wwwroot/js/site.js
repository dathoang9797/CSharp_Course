(function ($) {
    "use strict";

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    }

    connection.onclose(async () => {
        await start();
    });

    connection.on("receiveMsg", function (obj) {
        console.log({msg, obj})
        $("#rs").appendTo(`
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


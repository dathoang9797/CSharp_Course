(function ($) {
    "use strict";

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/notify")
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    };

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
    })

// Start the connection.
    start();
})(jQuery);


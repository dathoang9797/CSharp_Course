(function ($) {
    "use strict";

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");

            // $(".info").click(function () {
            //     $("#info").text($(this).text());
            //     $(frm['userId']).val($(this).attr("val"));
            // });

            $("#members").on("click", "li.info", function () {
                $(frm['msg']).removeAttr("disabled")
                $("#info").text($(this).text());
                const uid = $(this).attr("val");
                $(frm['userId']).val(uid);
                $("#rs").empty();

                $.post("/home/messages", {id: uid}, (data) => {
                    for (const obj of data) {
                        $("#rs").append(`
                         <li>
                            ${obj['senderName']}: <span>${obj['content']}</span>
                             <span class="cnt"></span>
                        </li>`)
                    }
                })
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
            const uid = obj['senderId'];
            const userId = $(frm['userId']).val();
            if (uid !== userId) {
                const cnt = $(`#members li[val="${uid}"] span.cnt`);
                if (cnt.text() === "") {
                    cnt.text("1");
                } else {
                    const text = cnt.text();
                    cnt.text(Number(text) + 1);
                }
            } else {
                $("#rs").append(`
             <li>
                ${obj['sender']}: <span>${obj['msg']}</span>
            </li>
        `)
            }
        }
    )

    connection.on("successMsg", (msg, obj) => {
        if (msg === "register") {
            $("#members").append(`
             <li class="info"
                 val="${obj["memberId"]}"
              >
            ${obj["givenName"]}  <span>false</span>
            </li>
          `)
        } else if (msg === "login") {
            const status = `#members li[val="${obj['memberId']}"] span.status`;
            $(status).text("true");
        }
    })

// Start the connection.
    start();
})(jQuery);


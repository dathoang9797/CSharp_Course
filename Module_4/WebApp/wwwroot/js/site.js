// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#img").click(function (){
})

$("#file").change(function (){
    const fd = new FormData();
    const file = this.files[0];

    fd.append("file",file,file.name);
    fd.append("isReturnJson", true); // Add the isReturnJson flag

    $.ajax({
        url: "/upload/add",
        data: fd,
        method: "post",
        contentType: false,
        processData: false,
        success(data) {
            console.log({data});
            $("#img").attr("src", `https://localhost:7070/images/${data}`);
            $('#ImageUrl').val(data);
        }
    })
})
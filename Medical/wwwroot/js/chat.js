
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (sendUser, message) {
    let user = $("#inpUser").val();
    var MSN = document.querySelector("#MSN");
    var time = moment(Date.now()).format("LTS")
    var role = "訪客";
    var role1 = "客服";
    if (user == 2 || user == 3) {
        role = "客服";
        role1 = "訪客";
    }
    if (user == sendUser) {
        
        $("#MSN").append(`<div class="direct-chat-msg text-md-end">
                                <div class="direct-chat-infos clearfix">
                                    <span class="direct-chat-name float-left" id="name_player1">《${role}》</span>
                                    <span class="direct-chat-timestamp float-right" id="time_player1">(${time})</span>
                                </div>
                                <img class="direct-chat-img" src="../img/${role}.jpg" alt="Message User Image" style="border-radius:50%">
                            <div class="direct-chat-text">
                                <span class="text-bold">${message}</span>
                            </div>
                            </div>`)

    }
    else{
        $("#MSN").append(`<div class="direct-chat-msg">
                        <div class="direct-chat-infos clearfix">
                            <span class="direct-chat-name float-left" id="name_player1">《${role1}》</span>
                            <span class="direct-chat-timestamp float-right" id="time_player1">(${time})</span>
                        </div>
                        <img class="direct-chat-img" src="../img/${role1}.jpg" alt="Message User Image" style="border-radius:50%">
                       
                    <div class="direct-chat-text">
                        <span class="text-bold">${message}</span>
                    </div>
                    </div>`)
    }
});


    //可新增
    //else {
    //    $("#MSN").append(`<div class="direct-chat-msg right text-md-start">
    //                    <div class="direct-chat-infos clearfix">
    //                        <span class="direct-chat-name float-left" id="name_player1">${user}</span>
    //                        <span class="direct-chat-timestamp float-right" id="time_player1">${time}</span>
    //                    </div>
    //                    <img class="direct-chat-img" src="../img/訪客.jpg" alt="Message User Image" style="border-radius:50%">
    //                <div class="direct-chat-text">
    //                    <ul id="message_player1">
    //                       <li>${message}</li>
    //                    </ul>
    //                </div>
    //                </div>`)
    //}
/*});*/



connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var sendUser = document.getElementById("inpUser").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage",sendUser,message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});



"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var MSN = document.querySelector("#MSN");
    var time = moment(Date.now()).format("LTS")
    if (user == `客服`) {
        
                $("#MSN").append(`<div class="direct-chat-msg right">
                                <div class="direct-chat-infos clearfix">
                                    <span class="direct-chat-name float-left" id="name_player1">客服</span>
                                    <span class="direct-chat-timestamp float-right" id="time_player1">${time}</span>
                                </div>
                                <img class="direct-chat-img" src="../img/客服.png" alt="Message User Image" style="border-radius:50%">
                            <div class="direct-chat-text">
                                <ul id="message_player1">
                                    <li>${message}</li>
                                </ul>
                            </div>
                            </div>`)

    }
    else if (user == "訪客") {
        
        $("#MSN").append(`<div class="direct-chat-msg">
                        <div class="direct-chat-infos clearfix">
                            <span class="direct-chat-name float-left" id="name_player1">訪客</span>
                            <span class="direct-chat-timestamp float-right" id="time_player1">${time}</span>
                        </div>
                        <img class="direct-chat-img" src="../img/訪客.jpg" alt="Message User Image" style="border-radius:50%">
                       
                    <div class="direct-chat-text">
                        <ul id="message_player1">
                                <li>${message}</li>
                        </ul>
                    </div>
                    </div>`)
    }
    else {
        $("#MSN").append(`<div class="direct-chat-msg right">
                        <div class="direct-chat-infos clearfix">
                            <span class="direct-chat-name float-left" id="name_player1">${user}</span>
                            <span class="direct-chat-timestamp float-right" id="time_player1">${time}</span>
                        </div>
                        <img class="direct-chat-img" src="../img/訪客.jpg" alt="Message User Image" style="border-radius:50%">
                    <div class="direct-chat-text">
                        <ul id="message_player1">
                           <li>${message}</li>
                        </ul>
                    </div>
                    </div>`)
    }
});



connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {

    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage",message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


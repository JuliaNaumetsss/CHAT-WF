﻿// -----------------------------------------------------------------------
// <copyright file="MessageRequest.cs" company="xsDevelopment">
//   Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0)
//   All Rights Reserved - See License.txt for more details
// </copyright>
// -----------------------------------------------------------------------
namespace serverExample.Handling
{
    using System;

    public class MessageRequest :ILoggedInHandle
    {
        public string GetCommandName()
        {
            return "MESSAGE REQUEST";
        }

        public void DoHandle(Client client, Packet packet)
        {
            string messageData = packet.Carriage;
            if (string.IsNullOrEmpty(messageData)) return;

            var sourceUser = Handle.OnlineUsers[client];

            if (sourceUser.Banned)
            {
                Packets.Message("Server", "You have been banned and cannot talk").Write(client);
                return;
            }

            Packets.Message(sourceUser.Nickname, messageData.Trim()).WriteAll();
            Console.WriteLine("[Chat] ({0}) {1}: {2}", sourceUser.Email, sourceUser.Nickname, messageData);
        }
    }
}

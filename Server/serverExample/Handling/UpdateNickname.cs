// -----------------------------------------------------------------------
// <copyright file="UpdateNickname.cs" company="xsDevelopment">
//   Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0)
//   All Rights Reserved - See License.txt for more details
// </copyright>
// -----------------------------------------------------------------------
namespace serverExample.Handling
{
    using System;

    public class UpdateNickname : ILoggedInHandle
    {
        public string GetCommandName()
        {
            return "UPDATE NICKNAME";
        }

        public void DoHandle(Client client, Packet packet)
        {
            var user = Handle.OnlineUsers[client];
            if (string.IsNullOrEmpty(packet.Carriage)) return;
            AdminTools.ChangeNickname(user, packet.Carriage.Trim());
            Console.WriteLine("[Info] {0} changed their nickname to {1}", user.Email, packet.Carriage.Trim());
        }
    }
}
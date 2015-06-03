// -----------------------------------------------------------------------
// <copyright file="Kill.cs" company="xsDevelopment">
//   Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0)
//   All Rights Reserved - See License.txt for more details
// </copyright>
// -----------------------------------------------------------------------
namespace serverExample.Handling
{
    using System;
    using Information;

    public class Kill : ILoggedInHandle
    {
        public string GetCommandName()
        {
            return "KILL";
        }

        public void DoHandle(Client client, Packet packet)
        {
            var currentUser = Handle.OnlineUsers[client];

            if (currentUser.Role != User.UserRole.Admin)
                return;

            int uid = Convert.ToInt32(packet.Carriage);

            AdminTools.DisconnectSessions(uid, "Connection discontinued by an administrator.");
        }
    }
}

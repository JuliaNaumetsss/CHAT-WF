

namespace clientExample
{
    using System;
    using System.Collections.Generic;
    public class Packet
    {
        public Packet(string rawdata)
        {
            int sepindex = rawdata.IndexOf(":", StringComparison.Ordinal);
            Command = rawdata.Substring(0, sepindex);
            Carriage = rawdata.Substring(Command.Length + 2);
        }

        public Packet(string command, string carriage)
        {
            Command = command;
            Carriage = carriage;
        }

        public string Serialize()
        {
            return string.Format("{0}: {1}", Command, Carriage.Replace("\0", ""));
        }

        public static implicit operator string(Packet value)
        {
            return value.Serialize();
        }

        public string Command { get; set; }
        public string Carriage { get; set; }
    }

    public static class Packets
    {
        public static Packet UpdateRole(string userid, Sets.UserRole newRole)
        {
            var package = new List<string>
                              {
                                 userid,
                                 newRole.ToString()
                              };
            return new Packet("UPDATE ROLE", package.Package());
        }
        public static Packet UpdateRole(string userid, string newRole)
        {
            var package = new List<string>
                              {
                                 userid,
                                 newRole
                              };
            return new Packet("UPDATE ROLE", package.Package());
        }
        public static Packet UpdatePassword(string newpass)
        {
            return new Packet("UPDATE PASSWORD", newpass);
        }
        public static Packet CreateRequest(string email, string password, string nickname)
        {
            var package = new List<string>
                              {
                                  email,
                                  password,
                                  nickname
                              };
            return new Packet("CREATE REQUEST", package.Package());
        }
        public static Packet UpdateNickname(string newNickname)
        {
            return new Packet("UPDATE NICKNAME", newNickname);
        }
        public static Packet Kill(string userId)
        {
            return new Packet("KILL", userId);
        }

        public static string Package(this List<string> raw)
        {
            return;
            //return DataMap.Serialize(raw);
        }
    }
}

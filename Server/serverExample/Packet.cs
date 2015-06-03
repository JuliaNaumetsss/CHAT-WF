﻿// -----------------------------------------------------------------------
// <copyright file="Packet.cs" company="xsDevelopment">
//   Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0)
//   All Rights Reserved - See License.txt for more details
// </copyright>
// -----------------------------------------------------------------------
namespace serverExample
{
    using System;

    public class Packet
    {
        public Packet()
        {
        }

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

        public string Command { get; set; }
        public string Carriage { get; set; }
    }
}

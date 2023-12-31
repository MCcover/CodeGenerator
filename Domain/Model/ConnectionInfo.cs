﻿using System.Net;
using System.Text.RegularExpressions;

namespace Domain.Model {

	public class ConnectionInfo {
		const string IP_PATTERN = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

		public IPAddress Ip { get; set; }
		public int Port { get; set; }
		public string DatabaseName { get; set; }
		public string DatabaseUser { get; set; }
		public string DatabasePassword { get; set; }

		public ConnectionInfo(string ip, int port, string databaseName, string databaseUser, string databasePassword) {

			var validIp = Regex.IsMatch(ip, IP_PATTERN);
			if (!validIp) {
				throw new Exception("Invalid Ip");
			}

			var octates = ip.Split('.').Select(x => Convert.ToByte(x)).ToArray();

			Ip = new IPAddress(octates);

			if (port <= 0 || port > 65535) {
				throw new Exception("Invalid Port");
			}

			Port = port;

			if (databaseName.Trim() == string.Empty) {
				throw new Exception("Invalid Database Name");
			}

			DatabaseName = databaseName;

			if (databaseUser.Trim() == string.Empty) {
				throw new Exception("Invalid Database User");
			}
			DatabaseUser = databaseUser;

			DatabasePassword = databasePassword;

		}

	}
}

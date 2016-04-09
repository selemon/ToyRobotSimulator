using System;

namespace ToyRobotSimulator
{
	class MainClass
	{
		private const int TABLE_SIZE = 5;
		private int x = -1;
		private int y = -1;
		private string direction;

		public MainClass()
		{
			
		}


		public void command(string command){

//			Console.WriteLine ("in command");

			if(command.StartsWith("PLACE")){
				string[] tokens = command.Split(' ');
				if (tokens.Length < 2) {
					Console.WriteLine ("Please provide correct PLACE statement");
				} else {
					string[] t = tokens [1].Split (',');
					if (t.Length < 3) {
						Console.WriteLine ("Please provide correct PLACE statement");
					} else {
						int xx = int.Parse (t [0]);
						int yy = int.Parse (t [1]);
						string direc = t [2];
						if (xx < 0 || yy < 0 || xx >= TABLE_SIZE || yy >= TABLE_SIZE) {
							Console.WriteLine ("Robot needs to be placed in a proper place");
						} else {
							x = xx;
							y = yy;
							direction = direc;
						}
					}
				}
			}else if(command.StartsWith("MOVE")){
				if (x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE) {
					Console.WriteLine ("Robot cant move here");
				} else {

					int newx = GetXDestination ();
					int newy = GetYDestination ();
					x = newx;
					y = newy;
				}
			}else if(command.StartsWith("LEFT")){
				if (x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE) {
					Console.WriteLine ("Robot is not on the table");
				} else {
					if (direction.Equals ("EAST")) {
						direction = "NORTH";
					} else if (direction.Equals ("SOUTH")) {
						direction = "EAST";
					} else if (direction.Equals ("WEST")) {
						direction = "SOUTH";
					} else if (direction.Equals ("NORTH")) {
						direction = "WEST";
					}
				}


			}else if(command.StartsWith("RIGHT")){
				if (x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE) {
					Console.WriteLine ("Robot is not on the table");
				} else {
					if (direction.Equals ("EAST")) {
						direction = "SOUTH";
					} else if (direction.Equals ("SOUTH")) {
						direction = "WEST";
					} else if (direction.Equals ("WEST")) {
						direction = "NORTH";
					} else if (direction.Equals ("NORTH")) {
						direction = "EAST";
					}
				}

			}else if(command.StartsWith("REPORT")){
				if (x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE) {
					Console.WriteLine ("Robot is not on the table");
				} else {
					Console.WriteLine ("Output: " + x + "," + y + "," + direction);
				}
			}


		}

		private int GetXDestination()
		{
			if (direction.Equals("EAST"))
			{
				return x += 1;
			}
			else 
			{
				if (direction.Equals("WEST")) 
				{
					return x -= 1;
				}
			}
			return x;
		}

		private int GetYDestination()
		{
			if (direction.Equals("NORTH"))
			{
				return y += 1;
			}
			else
			{
				if (direction.Equals("SOUTH"))
				{
					return y -= 1;
				}
			}
			return y;
		}



		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello There! Lets Play");
//			Console.WriteLine ("Hello Selemon!");
			MainClass robot = new MainClass();


			while (true)
			{
				Console.WriteLine("#: ");
				string command = Console.ReadLine();
//				Console.WriteLine ("user said: " + command);
				if (command.ToUpper() == "EXIT" || command.ToUpper() == "QUIT")
				{
					Environment.Exit(0);
				}
				robot.command(command.ToUpper());
			}


		}


	}
}

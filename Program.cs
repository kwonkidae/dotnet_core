using System;

namespace first
{
	public struct RGBColor {
		public RGBColor(Int16 R, Int16 G, Int16 B) {

		}

		int M()
		{
			int y = 5;
			int x = 7;
			return Add(x, y);
			static int Add(int left, int right) => left + right;
		}
	}

	public struct Address {
		public string State { get; set; }
		public Address(string state){
			this.State = state;
		}
	}
	public struct Point {
		public double X { get; set; }
		public double Y { get; set; }

		public readonly double Distance => Math.Sqrt(X * X + Y * Y);

		public readonly override string ToString() =>
			$"({X}, {Y}) is {Distance} from the origin";
		
		public void Translate(int xOffset, int yOffSet) {
			X += xOffset;
			Y += yOffSet;
		}

		public void Deconstruct(out int x, out int y) =>
			(x, y) = ((int)X, (int)Y);
	}
	class Program
	{
		public static RGBColor FromRainbowClassic(Rainbow colorBand) =>
			colorBand switch 
			{
				Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
				Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
				Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
				Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
				Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
				Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
				Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
				_ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
			};
		
		public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
			location switch
			{
				{ State: "WA" } => salePrice * 0.06M,
				{ State: "MN" } => salePrice * 0.75M,
				{ State: "MI"} => salePrice * 0.05M,
				_ => 0M
			};

		public static string RockPaperScissors(string first, string second) 
			=> (first, second) switch
			{
				("rock", "paper") => "rock is covered by paper. Paper wins.",
				(_, _) => "tie"
			};
		
		static Quadrant GetQuadrant(Point point) => point switch
		{
			(0, 0) => Quadrant.Origin,
			var (x ,y) when x > 0 && y > 0 => Quadrant.One,
			var (x, y) when x < 0 && y > 0 => Quadrant.Two,
			var (x, y) when x < 0 && y < 0 => Quadrant.Three,
			var (x, y) when x > 0 && y < 0 => Quadrant.Four,
			var (_, _) => Quadrant.OnBorder
		};
		static void Main(string[] args)
		{
			var point = new Point();
			var Red = FromRainbowClassic(Rainbow.Violet);
			int x, y;
			new MyPoint(1, 2).Destruct(out x, out y);

			var address = new Address("WA");
			Console.WriteLine(ComputeSalesTax(address, 4));
			Console.WriteLine($"{x}, {y}");
			Console.WriteLine(Red);
			Console.WriteLine(Red);
			point.X = 5;
			point.Y = 10;
			Console.WriteLine(point);
			Console.WriteLine("Hello World!");
			Console.WriteLine(RockPaperScissors("rock", "paper"));
			Console.WriteLine(GetQuadrant(point));
		}
	}
}

namespace first {
	public enum Rainbow {
		Red,
		Orange,
		Yellow,
		Green,
		Blue,
		Indigo,
		Violet
	}

	public class MyPoint {
		public int X { get; }
		public int Y { get; }

		public MyPoint(int x, int y) => (X, Y) = (x, y);

		public void Destruct(out int x, out int y) =>
			(x, y) = (X, Y);
	}

	public enum Quadrant
	{
		Unknown,
		Origin,
		One,
		Two,
		Three,
		Four,
		OnBorder
	}
}

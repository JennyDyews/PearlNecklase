﻿namespace PearlNecklace
{
    public class Pearl : IPearl
    {
        public const decimal PearlBasePrice = 50M;
        public const int PearlMinSize = 5;
        public const int PearlMaxSize = 25;
        public int Size { get; set; }
        public PearlColor Color { get; set; }
        public PearlShape Shape { get; set; }
        public PearlType Type { get; set; }
        public decimal Price
        {
            get
            {
                var price = Size * PearlBasePrice;
                if (Type == PearlType.SaltWater)
                    price *= 2;
                return price;   
            }
        }

        public override string ToString() => $"{Size}mm {Color} {Shape} {Type} pearl. Price: {Price}";

        #region IComparable and IEquatable
        public int CompareTo(IPearl other)
        {
            if (Size != other.Size)
                return Size.CompareTo(other.Size);
            if (Color != other.Color)
                return Color.CompareTo(other.Color);

            return Shape.CompareTo(other.Shape);
        }

        public bool Equals(IPearl other) => (Size, Color, Shape, Type) == (other.Size, other.Color, other.Shape, other.Type);
        public override bool Equals(object obj) => Equals(obj as Pearl);
        public override int GetHashCode() => (Size, Color, Shape, Type).GetHashCode();
        #endregion

        #region Class Factory for creating an instance filled with Random data
        public void RandomInit()
        {
            var rnd = new Random();
            this.Size = rnd.Next(PearlMinSize, PearlMaxSize);
            this.Color = (PearlColor)rnd.Next((int)PearlColor.Black, (int)PearlColor.Pink + 1);
            this.Shape = (PearlShape)rnd.Next((int)PearlShape.Round, (int)PearlShape.DropShaped + 1);
            this.Type = (PearlType)rnd.Next((int)PearlType.FreshWater, (int)PearlType.SaltWater + 1);
        }
        internal static class Factory
        {
            internal static IPearl CreateRandomPearl()
            {
                var p = new Pearl();
                p.RandomInit();
                return p;
            }
        }
        #endregion
    }
}

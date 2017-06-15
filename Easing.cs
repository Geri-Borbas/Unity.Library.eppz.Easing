using UnityEngine;
using System.Collections;


namespace EPPZ.Easing
{


	public static class Float_Extensions
	{
		public static float ValueWithEasingType(this float _this, Easing.EasingType easingType)
		{ return Easing.EasingForType(easingType).ValueForInput(_this); }

		public static float ValueWithEasing(this float _this, Easing easing)
		{ return easing.ValueForInput(_this); }
	}


	public class Easing
	{
		public enum EasingType
		{
			Linear,

			// Exponential

			EaseIn,
			EaseIn2,
			EaseIn3,

			EaseOut,
			EaseOut2,
			EaseOut3,

			EaseInOut,
			EaseInOut2,
			EaseInOut3,

			// Circular

			EaseInCircular,
			EaseOutCircular,
			EaseInOutCircular,

			// Bounce

			EaseInBounce,
			EaseInBounce2,
			EaseInBounce3,

			EaseOutBounce,
			EaseOutBounce2,
			EaseOutBounce3,

			EaseInOutBounce,
			EaseInOutBounce2,
			EaseInOutBounce3

		}

		private static Easing[] _easingPool = new Easing[]
		{
			new Linear(),
			new EaseIn(),
			new EaseIn2(),
			new EaseIn3(),
			new EaseOut(),
			new EaseOut2(),
			new EaseOut3(),
			new EaseInOut(),
			new EaseInOut2(),
			new EaseInOut3(),
			new EaseInCircular(),
			new EaseOutCircular(),
			new EaseInOutCircular(),
			new EaseInBounce(),
			new EaseInBounce2(),
			new EaseInBounce3(),
			new EaseOutBounce(),
			new EaseOutBounce2(),
			new EaseOutBounce3(),
			new EaseInOutBounce(),
			new EaseInOutBounce2(),
			new EaseInOutBounce3()
		};

		public static Easing EasingForType(EasingType type)
		{ return _easingPool[(int)type]; }

		public virtual EasingType type { get { return 0; } }
		public virtual string name { get { return null; } }
		public virtual string description { get { return null; } }
		public virtual string algorithm { get { return null; } }
		public virtual string simplifiedAlgorithm { get { return algorithm; } }
		public virtual float ValueForInput(float x) { return x; }
	}


	public class Linear : Easing
	{
		public override EasingType type { get { return EasingType.Linear; } }
		public override string name { get { return "Linear"; } }
		public override string description { get { return "No easing"; } }
		public override string algorithm { get { return "y = x"; } } // http://fooplot.com/plot/dnmxpux77q
		public override float ValueForInput(float x)
		{
			return x;
		}
	}


	public class EaseIn : Easing
	{
		public override EasingType type { get { return EasingType.EaseIn; } }
		public override string name { get { return "Ease In"; } }
		public override string description { get { return "Quadratic"; } }
		public override string algorithm { get { return "y = x^2"; } }
		public override float ValueForInput(float x)
		{
			return Mathf.Pow(x, 2);
		}
	}


	public class EaseIn2 : Easing
	{
		public override EasingType type { get { return EasingType.EaseIn2; } }
		public override string name { get { return "Ease In 2"; } }
		public override string description { get { return "Cubic"; } }
		public override string algorithm { get { return "y = x^3"; } }
		public override float ValueForInput(float x)
		{
			return Mathf.Pow(x, 3);
		}
	}


	public class EaseIn3 : Easing
	{
		public override EasingType type { get { return EasingType.EaseIn3; } }
		public override string name { get { return "Ease In 3"; } }
		public override string description { get { return "Octic"; } }
		public override string algorithm { get { return "y = x^8"; } }
		public override float ValueForInput(float x)
		{
			return Mathf.Pow(x, 8);
		}
	}


	public class EaseOut : Easing
	{
		public override EasingType type { get { return EasingType.EaseOut; } }
		public override string name { get { return "Ease Out"; } }
		public override string description { get { return "Inverse quadratic"; } }
		public override string algorithm { get { return "y = 1-(1-x)^2"; } }
		public override float ValueForInput(float x)
		{
			return 1 - Mathf.Pow(1 - x, 2);
		}
	}


	public class EaseOut2 : Easing
	{
		public override EasingType type { get { return EasingType.EaseOut2; } }
		public override string name { get { return "Ease Out 2"; } }
		public override string description { get { return "Inverse cubic"; } }
		public override string algorithm { get { return "y = 1-(1-x)^3"; } }
		public override float ValueForInput(float x)
		{
			return 2 * x - Mathf.Pow(x, 2);
		}
	}


	public class EaseOut3 : Easing
	{
		public override EasingType type { get { return EasingType.EaseOut3; } }
		public override string name { get { return "Ease Out 3"; } }
		public override string description { get { return "Inverse octic"; } }
		public override string algorithm { get { return "y = 1-(1-x)^8"; } }
		public override float ValueForInput(float x)
		{
			return 1 - Mathf.Pow(1 - x, 8);
		}
	}


	public class EaseInOut : Easing
	{
		public override EasingType type { get { return EasingType.EaseInOut; } }
		public override string name { get { return "Ease In Out"; } }
		public override string description { get { return "Shrink, offset, simplify In / Out"; } }
		public override string algorithm { get { return "y = (x<0.5) ? (2x)^2/2 : 0.5+(1-(2(1-x))^2)/2"; } }
		public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 2x^2 : -2x^2+4x-1"; } }
		public override float ValueForInput(float x)
		{
			return (x < 0.5f)
				? 2 * Mathf.Pow(x, 2)
					: -2 * Mathf.Pow(x, 2) + 4 * x - 1;
		}
	}


	public class EaseInOut2 : Easing
	{
		public override EasingType type { get { return EasingType.EaseInOut2; } }
		public override string name { get { return "Ease In Out 2"; } }
		public override string description { get { return "Shrink, offset, simplify In / Out"; } }
		public override string algorithm { get { return "y = (x<0.5) ? (2x)^3/2 : 0.5+(1-(2(1-x))^3)/2"; } }
		public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 4x^3 : 4x^3-12x^2+12x-3"; } }
		public override float ValueForInput(float x)
		{
			return (x < 0.5f)
				? 4 * Mathf.Pow(x, 3)
					: 4 * Mathf.Pow(x, 3) - 12 * Mathf.Pow(x, 2) + 12 * x - 3;
		}
	}


	public class EaseInOut3 : Easing
	{
		public override EasingType type { get { return EasingType.EaseInOut3; } }
		public override string name { get { return "Ease In Out 3"; } }
		public override string description { get { return "Shrink, offset, simplify In / Out"; } }
		public override string algorithm { get { return "y = (x<0.5) ? (2x)^8/2 : 0.5+(1-(2(1-x))^8)/2"; } }
		public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 128x^8 : 0.5+(1-(2(1-x))^8)/2"; } }
		public override float ValueForInput(float x)
		{
			return (x < 0.5f)
				? 128 * Mathf.Pow(x, 8)
					: 0.5f + (1 - Mathf.Pow((1 - x) * 2, 8)) / 2;
		}
	}


	public class EaseInCircular : Easing
	{
		public override EasingType type { get { return EasingType.EaseInCircular; } }
		public override string name { get { return "Ease In Circular"; } }
		public override string description { get { return "Inverse square root, inverse power"; } }
		public override string algorithm { get { return "y = 1-sqrt(1-x^2)"; } }
		public override float ValueForInput(float x)
		{
			return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
		}
	}


	public class EaseOutCircular : Easing
	{
		public override EasingType type { get { return EasingType.EaseOutCircular; } }
		public override string name { get { return "Ease Out Circular"; } }
		public override string description { get { return "Square root, power, inverse"; } }
		public override string algorithm { get { return "y = sqrt(1-(1-x)^2)"; } }
		public override string simplifiedAlgorithm { get { return "y = sqrt(-(x-2)x)"; } }
		public override float ValueForInput(float x)
		{
			return Mathf.Sqrt(-(x - 2) * x);
		}
	}


	public class EaseInOutCircular : Easing
	{
		public override EasingType type { get { return EasingType.EaseInOutCircular; } }
		public override string name { get { return "Ease In Out Circular"; } }
		public override string description { get { return "Shrink, offset, simplify In / Out"; } }
		public override string algorithm { get { return "y = (x<0.5) ? (1-sqrt(1-(2x)^2))/2 : 0.5+sqrt(1-((2(1-x))^2))/2"; } }
		public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 0.5(1-sqrt(1-4x^2)) : 0.5(sqrt(-4(x-2)x-3)+1)"; } }
		public override float ValueForInput(float x)
		{
			return (x < 0.5f) 
				? 0.5f * (1 - Mathf.Sqrt(1 - 4 * Mathf.Pow(x, 2)))
					: 0.5f * (Mathf.Sqrt(-4 * (x - 2) * x - 3) + 1);
		}
	}


	public class EaseInBounce : Easing
	{
		public override EasingType type { get { return EasingType.EaseInBounce; } }
		public override string name { get { return "Ease In Bounce"; } }
		public override string description { get { return "Offset power composition"; } }
		public override string algorithm { get { return "y = 2x^3-x^2"; } }
		public override string simplifiedAlgorithm { get { return "y = x^2(2x-1)"; } }
		public override float ValueForInput(float x)
		{
			return Mathf.Pow(x, 2) * (2 * x - 1);
		}
	}


	public class EaseInBounce2 : Easing
	{
		public override EasingType type { get { return EasingType.EaseInBounce2; } }
		public override string name { get { return "Ease In Bounce 2"; } }
		public override string description { get { return "Offset power composition"; } }
		public override string algorithm { get { return "y = 3x^3-2x^2"; } }
		public override string simplifiedAlgorithm { get { return "y = x^2(3x-2)"; } }
		public override float ValueForInput(float x)
		{
			return Mathf.Pow(x, 2) * (3 * x - 2);
		}
	}


	public class EaseInBounce3 : Easing
	{
		public override EasingType type { get { return EasingType.EaseInBounce3; } }
		public override string name { get { return "Ease In Bounce 3"; } }
		public override string description { get { return "Offset power composition"; } }
		public override string algorithm { get { return "y = 4x^3-3x^2"; } }
		public override string simplifiedAlgorithm { get { return "y = x^2(4x-3)"; } }
		public override float ValueForInput(float x)
		{
			return Mathf.Pow(x, 2) * (4 * x - 3);
		}
	}


	public class EaseOutBounce : Easing
	{
		public override EasingType type { get { return EasingType.EaseOutBounce; } }
		public override string name { get { return "Ease Out Bounce"; } }
		public override string description { get { return "Inverse offset power composition"; } }
		public override string algorithm { get { return "y = 1-(2(1-x)^3-(1-x)^2)"; } }
		public override string simplifiedAlgorithm { get { return "y = x(x(2x-5)+4)"; } }
		public override float ValueForInput(float x)
		{
			return x * ( x * (2 * x - 5 ) + 4);
		}
	}

	public class EaseOutBounce2 : Easing
	{
		public override EasingType type { get { return EasingType.EaseOutBounce2; } }
		public override string name { get { return "Ease Out Bounce 2"; } }
		public override string description { get { return "Inverse offfset power composition"; } }
		public override string algorithm { get { return "y = 1-(3(1-x)^3-2(1-x)^2)"; } }
		public override string simplifiedAlgorithm { get { return "y = x(x(3x-7)+5)"; } }
		public override float ValueForInput(float x)
		{
			return x * ( x * (3 * x - 7 ) + 5);
		}
	}


	public class EaseOutBounce3 : Easing
	{
		public override EasingType type { get { return EasingType.EaseOutBounce3; } }
		public override string name { get { return "Ease Out Bounce 3"; } }
		public override string description { get { return "Inverse offset power composition"; } }
		public override string algorithm { get { return "y = 1-(4(1-x)^3-3(1-x)^2)"; } }
		public override string simplifiedAlgorithm { get { return "y = x(x(4x-9)+6)"; } }
		public override float ValueForInput(float x)
		{
			return x * ( x * (4 * x - 9 ) + 6);
		}
	}


	public class EaseInOutBounce : Easing
	{
		public override EasingType type { get { return EasingType.EaseInOutBounce; } }
		public override string name { get { return "Ease In Out Bounce"; } }
		public override string description { get { return "Shrink, offset, simplify In / Out"; } }
		public override string algorithm { get { return "y = (x<0.5) ? (2(2x)^3-(2x)^2)*0.5 : 1-(2(2(1-x))^3-(2(1-x))^2)*0.5"; } }
		public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 8x^3-2x^2 : 8x^3-22x^2+20x-5"; } }
		public override float ValueForInput(float x)
		{
			return (x < 0.5f) 
				? 8 * Mathf.Pow(x, 3) - 2 * Mathf.Pow(x, 2)
					: 8 * Mathf.Pow(x, 3) - 22 * Mathf.Pow(x, 2) + 20 * x - 5;
		}
	}


	public class EaseInOutBounce2 : Easing
	{
		public override EasingType type { get { return EasingType.EaseInOutBounce2; } }
		public override string name { get { return "Ease In Out Bounce 2"; } }
		public override string description { get { return "Shrink, offset, simplify In / Out"; } }
		public override string algorithm { get { return "y = (x<0.5) ? (3(2x)^3- (2x)^2)*0.5 : 1-(3(2(1-x))^3-2(2(1-x))^2)*0.5"; } }
		public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 12x^3-4x^2 : 12x^3-32x^2+28x-7"; } }
		public override float ValueForInput(float x)
		{
			return (x < 0.5f) 
				? 12 * Mathf.Pow(x, 3) - 4 * Mathf.Pow(x, 2)
					: 12 * Mathf.Pow(x, 3) - 32 * Mathf.Pow(x, 2) + 28 * x - 7;
		}
	}


	public class EaseInOutBounce3 : Easing
	{
		public override EasingType type { get { return EasingType.EaseInOutBounce3; } }
		public override string name { get { return "Ease In Out Bounce 3"; } }
		public override string description { get { return "Shrink, offset In / Out"; } }
		public override string algorithm { get { return "y = ((x<0.5) ? (4(2x)^3-3(2x)^2)*0.5 : 1-(4(2(1-x))^3-3(2(1-x))^2)*0.5"; } }
		public override string simplifiedAlgorithm { get { return "y = (x<0.5) ? 16x^3-6x^2 : 16x^3-42x^2+36x-9"; } }
		public override float ValueForInput(float x)
		{
			return (x < 0.5f) 
				? 16 * Mathf.Pow(x, 3) - 6 * Mathf.Pow(x, 2)
					: 16 * Mathf.Pow(x, 3) - 42 * Mathf.Pow(x, 2) + 36 * x - 9;
		}
	}
}

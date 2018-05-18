using System;
namespace Question1
{
	public class ServiceItem
	{
		private double _UnitCount;
		private string _Description;
		private double _Usage;

		public ServiceItem(double unitCount, string description, double usage)
		{
			_UnitCount = unitCount;
			_Description = description;
			_Usage = usage;

		}
		public double UnitCount
		{
			get
			{
				return _UnitCount;
			}
		}

		public string Description
		{
			get
			{
				return _Description;
			}
		}

		public double Usage
		{
			get
			{
				return _Usage;
			}
		}

		public override string ToString()
		{
			return string.Format("{0,-30}{1,-4}\t{2,-5}\t{3,-8}", _Description, _UnitCount, _Usage, (_Usage * _UnitCount));
		}
	}

}

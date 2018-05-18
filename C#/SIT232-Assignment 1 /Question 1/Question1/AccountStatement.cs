using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Question1
{
	public class AccountStatement
	{
		private List<ServiceItem> _Items = new List<ServiceItem>();

		public AccountStatement()
		{

		}
        public ReadOnlyCollection<ServiceItem> Items {
        get { return _Items.AsReadOnly(); } 
        }
        
		public string GetText()
		{
			{
				StringBuilder sb = new StringBuilder();
				// Append to StringBuilder from loop.
				foreach (ServiceItem item in _Items)
				{
					double UnitCount = item.UnitCount;
					double Usage = item.UnitCount;
                    string Description = item.Description;

					double Calculated = (Convert.ToDouble(UnitCount) * Convert.ToDouble(Usage));
					string CalculatedString = Calculated.ToString();


                    sb.Append(Description).Append(UnitCount).Append(Usage).Append(CalculatedString).AppendLine();
				}
				//return null;
				return sb.ToString();
			}
		}


		public bool Add(ServiceItem item)
		{
            if (item != null)
			    _Items.Add(item);
			return true;

		}
	}
}

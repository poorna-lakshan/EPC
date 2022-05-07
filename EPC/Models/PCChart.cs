﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EPC.Models
{
    public class PCChart
    {
		[DataContract]
		public class DataPoint
		{
			public DataPoint(double x, double y)
			{
				this.X = x;
				this.Y = y;
			}

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "x")]
			public Nullable<double> X = null;

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "y")]
			public Nullable<double> Y = null;
		}
	}
}
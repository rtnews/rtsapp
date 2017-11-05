using System;
using System.Collections.Generic;

namespace rtnews
{
    public abstract class Reader : ISerialize
    {
        public abstract void RunNumber(ref sbyte nValue, string nName);
        public abstract void RunNumbers(ref sbyte nValue, string nName);
		public void RunNumber(ICollection<sbyte> nValue, string nNames, string nName)
		{
			if (this.IsText()) {
				this.PushArray(nNames);
				sbyte value = 0;
				bool result = this.RunChild(nName);
				while (result) {
					this.RunNumbers(ref value, nName);
                    nValue.Add(value);
					value = 0;
					result = this.RunNext(nName);
				}
				this.PopArray(nNames);
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					sbyte value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberCount(ref sbyte nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				nName += "_"; nName += nCount;
				this.RunNumber(ref nValue, nName);
			} else {
				this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount(ICollection<sbyte> nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				sbyte value = 0;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
					if (0 != value) {
						nValue.Add(value);
                        value = 0;
                    }
				}
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					sbyte value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberSemi(ICollection<sbyte> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(Convert.ToSByte(i));
				}
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					sbyte value = 0;
					this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
		}

        public abstract void RunNumber(ref byte nValue, string nName);
        public abstract void RunNumbers(ref byte nValue, string nName);
        public void RunNumber(ICollection<byte> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                byte value = 0;
                bool result = this.RunChild(nName);
                while (result) {
                    this.RunNumbers(ref value, nName);
                    nValue.Add(value);
                    value = 0;
                    result = this.RunNext(nName);
                }
                this.PopArray(nNames);
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    byte value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberCount(ref byte nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
            } else {
                this.RunNumber(ref nValue, nName);
            }
        }
        public void RunNumberCount(ICollection<byte> nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                byte value = 0;
                for (sbyte i = 0; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                    if (0 != value) {
                        nValue.Add(value);
                        value = 0;
                    }
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    byte value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberSemi(ICollection<byte> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                this.RunNumber(ref value, nName);
                string[] t = value.Split(':');
                foreach (string i in t) {
                    nValue.Add(Convert.ToByte(i));
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    byte value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }

        public abstract void RunNumber(ref short nValue, string nName);
        public abstract void RunNumbers(ref short nValue, string nName);
        public void RunNumber(ICollection<short> nValue, string nNames, string nName)
		{
			if (this.IsText()) {
				this.PushArray(nNames);
				short value = 0;
				bool result = this.RunChild(nName);
				while (result) {
					this.RunNumbers(ref value, nName);
                    nValue.Add(value);
					value = 0;
                    result = this.RunNext(nName);
				}
				this.PopArray(nNames);
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					short value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberCount(ref short nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				nName += "_"; nName += nCount;
				this.RunNumber(ref nValue, nName);
			} else {
				this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount(ICollection<short> nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				short value = 0;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
					if (0 != value) {
						nValue.Add(value);
                        value = 0;
                    }
                }
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					short value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberSemi(ICollection<short> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(Convert.ToInt16(i));
				}
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					short value = 0;
					this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
		}

        public abstract void RunNumber(ref ushort nValue, string nName);
        public abstract void RunNumbers(ref ushort nValue, string nName);
        public void RunNumber(ICollection<ushort> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                ushort value = 0;
                bool result = this.RunChild(nName);
                while (result) {
                    this.RunNumbers(ref value, nName);
                    nValue.Add(value);
                    value = 0;
                    result = this.RunNext(nName);
                }
                this.PopArray(nNames);
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    ushort value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberCount(ref ushort nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
            } else {
                this.RunNumber(ref nValue, nName);
            }
        }
        public void RunNumberCount(ICollection<ushort> nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                ushort value = 0;
                for (sbyte i = 0; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                    if (0 != value) {
                        nValue.Add(value);
                        value = 0;
                    }
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    ushort value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberSemi(ICollection<ushort> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                this.RunNumber(ref value, nName);
                string[] t = value.Split(':');
                foreach (string i in t) {
                    nValue.Add(Convert.ToUInt16(i));
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    ushort value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }

        public abstract void RunNumber(ref int nValue, string nName);
        public abstract void RunNumbers(ref int nValue, string nName);
        public void RunNumber(ICollection<int> nValue, string nNames, string nName)
		{
			if (this.IsText()) {
				this.PushArray(nNames);
				int value = 0;
				bool result = this.RunChild(nName);
				while (result) {
					this.RunNumbers(ref value, nName);
                    nValue.Add(value);
					value = 0;
					result = this.RunNext(nName);
				}
				this.PopArray(nNames);
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					int value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberCount(ref int nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				nName += "_"; nName += nCount;
				this.RunNumber(ref nValue, nName);
			} else {
				this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount(ICollection<int> nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				int value = 0;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
					if (0 != value) {
						nValue.Add(value);
                        value = 0;
                    }
                }
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					int value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberSemi(ICollection<int> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(Convert.ToInt32(i));
				}
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					int value = 0;
					this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
		}

        public abstract void RunNumber(ref uint nValue, string nName);
        public abstract void RunNumbers(ref uint nValue, string nName);
        public void RunNumber(ICollection<uint> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                uint value = 0;
                bool result = this.RunChild(nName);
                while (result) {
                    this.RunNumbers(ref value, nName);
                    if (0 != value) {
                        nValue.Add(value);
                        value = 0;
                    }
                    result = this.RunNext(nName);
                }
                this.PopArray(nNames);
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    uint value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberCount(ref uint nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
            } else {
                this.RunNumber(ref nValue, nName);
            }
        }
        public void RunNumberCount(ICollection<uint> nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                uint value = 0;
                for (sbyte i = 0; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                    if (0 != value) {
                        nValue.Add(value);
                        value = 0;
                    }
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    uint value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberSemi(ICollection<uint> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                this.RunNumber(ref value, nName);
                string[] t = value.Split(':');
                foreach (string i in t) {
                    nValue.Add(Convert.ToUInt32(i));
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    uint value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }

        public abstract void RunNumber(ref long nValue, string nName);
        public abstract void RunNumbers(ref long nValue, string nName);
        public void RunNumber(ICollection<long> nValue, string nNames, string nName)
		{
			if (this.IsText()) {
				this.PushArray(nNames);
                long value = 0;
				bool result = this.RunChild(nName);
				while (result) {
					this.RunNumbers(ref value, nName);
					if (0 != value) {
						nValue.Add(value);
                        value = 0;
                    }
                    result = this.RunNext(nName);
				}
				this.PopArray(nNames);
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
                    long value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberCount(ref long nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				nName += "_"; nName += nCount;
				this.RunNumber(ref nValue, nName);
			} else {
				this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount(ICollection<long> nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				long value = 0;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
					if (0 != value) {
						nValue.Add(value);
                        value = 0;
                    }
				}
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					long value = 0;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberSemi(ICollection<long> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(Convert.ToInt64(i));
				}
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					long value = 0;
					this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
		}

        public abstract void RunNumber(ref ulong nValue, string nName);
        public abstract void RunNumbers(ref ulong nValue, string nName);
        public void RunNumber(ICollection<ulong> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                ulong value = 0;
                bool result = this.RunChild(nName);
                while (result) {
                    this.RunNumbers(ref value, nName);
                    if (0 != value) {
                        nValue.Add(value);
                        value = 0;
                    }
                    result = this.RunNext(nName);
                }
                this.PopArray(nNames);
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    ulong value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberCount(ref ulong nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
            } else {
                this.RunNumber(ref nValue, nName);
            }
        }
        public void RunNumberCount(ICollection<ulong> nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                ulong value = 0;
                for (sbyte i = 0; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                    if (0 != value) {
                        nValue.Add(value);
                        value = 0;
                    }
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    ulong value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }
        public void RunNumberSemi(ICollection<ulong> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                this.RunNumber(ref value, nName);
                string[] t = value.Split(':');
                foreach (string i in t) {
                    nValue.Add(Convert.ToUInt64(i));
                }
            } else {
                short count = 0;
                this.RunNumber(ref count, nName);
                for (short i = 0; i < count; ++i) {
                    ulong value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
                }
            }
        }

        public abstract void RunNumber(ref float nValue, string nName);
        public abstract void RunNumbers(ref float nValue, string nName);
        public void RunNumber(ICollection<float> nValue, string nNames, string nName)
		{
			if (this.IsText()) {
				this.PushArray(nNames);
				float value = 0f;
				bool result = this.RunChild(nName);
				while (result) {
					this.RunNumbers(ref value, nName);
					if (0f != value) {
						nValue.Add(value);
                        value = 0f;
                    }
					result = this.RunNext(nName);
				}
				this.PopArray(nNames);
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					float value = 0f;
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberCount(ref float nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount(ICollection<float> nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				float value = 0f;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
					if (0f != value) {
						nValue.Add(value);
                        value = 0f;
                    }
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					float value = 0f;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberSemi(ICollection<float> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
                this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(Convert.ToSingle(i));
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					float value = 0f;
					this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
		}

        public abstract void RunNumber(ref double nValue, string nName);
        public abstract void RunNumbers(ref double nValue, string nName);
        public void RunNumber(ICollection<double> nValue, string nNames, string nName)
		{
			if (this.IsText()) {
                this.PushArray(nNames);
				double value = 0d;
				bool result = this.RunChild(nName);
				while (result) {
                    this.RunNumbers(ref value, nName);
					if (0d != value) {
						nValue.Add(value);
                        value = 0d;
                    }
					result = this.RunNext(nName);
				}
                this.PopArray(nNames);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					double value = 0d;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberCount(ref double nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount(ICollection<double> nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				double value = 0d;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
					if (0d != value) {
						nValue.Add(value);
                        value = 0d;
                    }
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					double value = 0d;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberSemi(ICollection<double> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
                this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(Convert.ToDouble(i));
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					double value = 0d;
                    this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
		}

        public abstract void RunNumber(ref string nValue, string nName);
        public abstract void RunNumbers(ref string nValue, string nName);
        public void RunNumber(ICollection<string> nValue, string nNames, string nName)
		{
			if (this.IsText()) {
                this.PushArray(nNames);
				string value = "";
				bool result = this.RunChild(nName);
				while (result) {
                    this.RunNumbers(ref value, nName);
					if ("" != value) {
						nValue.Add(value);
                        value = "";
                    }
					result = this.RunNext(nName);
				}
				this.PopArray(nNames);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					string value = "";
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberCount(ref string nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount(ICollection<string> nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
				string value = "";
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
					if ("" != value) {
						nValue.Add(value);
                        value = "";
                    }
				}
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					string value = "";
					this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
		}
		public void RunNumberSemi(ICollection<string> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
                this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(i);
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i) {
					string value = "";
                    this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
		}

        public void RunCrc32(ref uint nValue, string nName)
        {
			if ( this.IsText() ) {
				string value = "";
                this.RunNumber(ref value, nName);
				nValue = HashId.RunCommon(value);
			} else {
                this.RunNumber(ref nValue, nName);
			}
        }
		public void RunCrc32(ICollection<uint> nValue, string nNames, string nName)
        {
			if ( this.IsText() ) {
                this.PushArray(nNames);
				string value = "";
				bool result = this.RunChild(nName);
				while ( result ) {
                    this.RunNumbers(ref value, nName);
					if ( value != "" ) {
						nValue.Add(HashId.RunCommon(value));
                        value = "";
                    }
					result = this.RunNext(nName);
				}
                this.PopArray(nNames);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
                    uint value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
        }
		public void RunCrc32Count(ref uint nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
				this.RunCrc32(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
        public void RunCrc32Count(ICollection<uint> nValue, string nName, sbyte nCount)
        {
			if ( this.IsText() ) {
                uint value = 0;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunCrc32Count(ref value, nName, i);
					if ( value != 0 ) {
						nValue.Add(value);
                        value = 0;
                    }
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
                    uint value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
        }
        public void RunCrc32Semi(ICollection<uint> nValue, string nName)
        {
			if ( this.IsText() ) {
				string value = "";
				this.RunNumber(ref value, nName);
				string[] t = value.Split(':');
				foreach (string i in t) {
					nValue.Add(HashId.RunCommon(i));
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i ) {
                    uint value = 0;
                    this.RunNumber(ref value, nName);
					nValue.Add(value);
				}
			}
        }

        public abstract void RunTime(ref ulong nValue, string nName);
        public abstract void RunTimes(ref ulong nValue, string nName);
        public void RunTime(ICollection<ulong> nValue, string nNames, string nName)
        {
			if ( this.IsText() ) {
                this.PushArray(nNames);
                ulong value = 0;
				bool result = this.RunChild(nName);
				while ( result ) {
                    this.RunTimes(ref value, nName);
					if ( value != 0 ) {
						nValue.Add(value);
                        value = 0;
                    }
					result = this.RunNext(nName);
				}
                this.PopArray(nNames);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for (short i = 0; i < count; ++i ) {
                    ulong value = 0;
                    this.RunTime(ref value, nName);
                    nValue.Add(value);
				}
			}
        }
		public void RunTimeCount(ref ulong nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
				this.RunTime(ref nValue, nName);
			} else {
                this.RunTime(ref nValue, nName);
			}
		}
        public void RunTimeCount(ICollection<ulong> nValue, string nName, sbyte nCount)
        {
			if ( this.IsText() ) {
                ulong value = 0;
				for (sbyte i = 0; i < nCount; ++i) {
					this.RunTimeCount(ref value, nName, i);
					if ( value != 0 ) {
						nValue.Add(value);
                        value = 0;
                    }
				}
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
                    ulong value = 0;
                    this.RunNumber(ref value, nName);
                    nValue.Add(value);
				}
			}
        }
        public void RunTimeSemi(ICollection<ulong> nValue, string nName)
        {
			if ( this.IsText() ) {
				LogEngine logEngine = LogEngine.Instance();
				logEngine.LogError(TAG, "RunTimeSemi", nName);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
                    ulong value = 0;
                    this.RunTime(ref value, nName);
					nValue.Add(value);
				}
			}
        }

        public abstract void RunBuffer(ref byte[] nValue, ref short nLength);

		public void RunStream<T>(T nValue, string nName) where T : IStream, new()
        {
			if (null == nValue) {
				nValue = new T ();
			}
			if ( this.IsText() ) {
                this.PushClass(nName);
				nValue.Serialize(this, nName, 0);
                this.PopClass(nName);
			} else {
				nValue.Serialize(this, nName, 0);
			}
        }
		public void RunStream<T>(ICollection<T> nValue, string nNames, string nName) where T : IStream, new()
        {
			if ( this.IsText() ) {
                this.PushArray(nNames);
				bool result = this.RunChild(nName);
				while ( result ) {
					T value = new T();
					value.Serialize(this, nName, 0);
					if (!value.IsDefault()) {
						nValue.Add(value);
					}
					result = this.RunNext(nName);
				}
                this.PopArray(nNames);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
					T value = new T();
					value.Serialize(this, nName, 0);
					if (!value.IsDefault()) {
						nValue.Add(value);
					}
				}
			}
        }
		public void RunStream<T0, T1>(IDictionary<T0, T1> nValue, string nNames, string nName) where T1 : IMapStream, new()
        {
			if ( this.IsText() ) {
                this.PushArray(nNames);
				bool result = this.RunChild(nName);
				while ( result ) {
					T1 value = new T1();
					value.Serialize(this, nName, 0);
					if (!value.IsDefault()) {
						nValue[value.mapIndex<T0>()] = value;
					}
					result = this.RunNext(nName);
				}
				this.PopArray(nNames);
			} else {
				short count = 0;
				this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
					T1 value = new T1();
					value.Serialize(this, nName, 0);
					if (!value.IsDefault()) {
						nValue[value.mapIndex<T0>()] = value;
					}
				}
			}
        }
		public void RunStreamCount<T>(T nValue, string nName, sbyte nCount) where T : IStream, new()
        {
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
                this.PushArray(nName);
				nValue.Serialize(this, nName, nCount);
                this.PopArray(nName);
			} else {
				nValue.Serialize(this, nName, 0);
			}
        }
        public void RunStreamCount<T>(ICollection<T> nValue, string nNames, string nName, sbyte nCount) where T : IStream, new()
        {
			if ( this.IsText() ) {
                this.PushArray(nNames);
				for (sbyte i = 0; i < nCount; ++i) {
					T value = new T();
					this.RunStreamCount(value, nName, i);
					if (value.IsDefault()) {
						continue;
					}
					nValue.Add(value);
				}
                this.PopArray(nNames);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
					T value = new T();
					value.Serialize(this, nName, 0);
					if (!value.IsDefault()) {
						nValue.Add(value);
					}
				}
			}
        }
        public void RunStreamCount<T0, T1>(IDictionary<T0, T1> nValue, string nNames, string nName, sbyte nCount) where T1 : IMapStream, new()
        {
			if ( this.IsText() ) {
                this.PushArray(nNames);
				for (sbyte i = 0; i < nCount; ++i) {
					T1 value = new T1();
					this.RunStreamCount(value, nName, i);
					if (value.IsDefault()) {
						continue;
					}
					nValue[value.mapIndex<T0>()] = value;
				}
                this.PopArray(nNames);
			} else {
				short count = 0;
                this.RunNumber(ref count, nName);
				for ( short i = 0; i < count; ++i ) {
					T1 value = new T1();
					value.Serialize(this, nName, 0);
					if (!value.IsDefault()) {
						nValue[value.mapIndex<T0>()] = value;
					}
				}
			}
        }

        public abstract void PushStream(string nName);
        public abstract void PopStream(string nName);

        public abstract void PushClass(string nName);
        public abstract void PopClass(string nName);

        public abstract void PushArray(string nName);
        public abstract bool RunChild(string nName);
        public abstract bool RunNext(string nName);
        public abstract void PopArray(string nName);

        public abstract bool IsText();

        public virtual void StringValue(string nName)
        {
        }

        public virtual bool LoadFile(string nName)
        {
            return false;
        }

        static readonly string TAG = typeof(Reader).Name;
    }
}

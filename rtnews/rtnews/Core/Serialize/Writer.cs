using System;
using System.Collections.Generic;

namespace rtnews
{
    public abstract class Writer : ISerialize
    {
        public abstract void RunNumber(ref sbyte nValue, string nName);
        public abstract void RunNumbers(ref sbyte nValue, string nName);
        public void RunNumber (ICollection<sbyte> nValue, string nNames, string nName)
		{
			if ( this.IsText() ) {
				this.PushArray(nNames);
				foreach (sbyte i in nValue) {
                    sbyte t = i;
					this.RunNumbers (ref t, nName);
				}
				this.PopArray(nNames);
			} else {
				short count = (short)(nValue.Count);
				this.RunNumber(ref count, nNames);
				foreach (sbyte i in nValue) {
                    sbyte t = i;
					this.RunNumber (ref t, nName);
				}
			}
		}
		public void RunNumberCount (ref sbyte nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
				this.RunNumber(ref nValue, nName);
			} else {
				this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount (ICollection<sbyte> nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				sbyte count = 0;
				foreach (sbyte i in nValue) {
					sbyte t = i;
					this.RunNumberCount(ref t, nName, count);
					count++;
				}
				sbyte value = 0;
				for (sbyte i = count; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
				}
			} else {
				short count = (short)(nValue.Count);
				this.RunNumber(ref count, nName);
				foreach (sbyte i in nValue) {
                    sbyte t = i;
					this.RunNumber(ref t, nName);
				}
			}
		}
		public void RunNumberSemi (ICollection<sbyte> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				int count = 0;
				foreach (sbyte i in nValue) {
					if (count > 0) {
						value += ":";
					} else {
						count++;
					}
					value += i;
				}
				this.RunNumber(ref value, nName);
			} else {
				short count = (short)(nValue.Count);
				this.RunNumber(ref count, nName);
				foreach (sbyte i in nValue) {
                    sbyte t = i;
					this.RunNumber(ref t, nName);
				}
			}
		}

        public abstract void RunNumber(ref byte nValue, string nName);
        public abstract void RunNumbers(ref byte nValue, string nName);
        public void RunNumber(ICollection<byte> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                foreach (byte i in nValue) {
                    byte t = i;
                    this.RunNumbers(ref t, nName);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
                foreach (byte i in nValue) {
                    byte t = i;
                    this.RunNumber(ref t, nName);
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
                sbyte count = 0;
                foreach (byte i in nValue) {
                    byte t = i;
                    this.RunNumberCount(ref t, nName, count);
                    count++;
                }
                sbyte value = 0;
                for (sbyte i = count; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                }
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (byte i in nValue) {
                    byte t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }
        public void RunNumberSemi(ICollection<byte> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                int count = 0;
                foreach (byte i in nValue) {
                    if (count > 0) {
                        value += ":";
                    } else {
                        count++;
                    }
                    value += i;
                }
                this.RunNumber(ref value, nName);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (byte i in nValue) {
                    byte t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }

        public abstract void RunNumber(ref short nValue, string nName);
        public abstract void RunNumbers(ref short nValue, string nName);
        public void RunNumber (ICollection<short> nValue, string nNames, string nName)
		{
			if ( this.IsText() ) {
                this.PushArray(nNames);
				foreach (short i in nValue) {
                    short t = i;
                    this.RunNumbers (ref t, nName);
				}
				this.PopArray(nNames);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
				foreach (short i in nValue) {
                    short t = i;
                    this.RunNumber (ref t, nName);
				}
			}
		}
		public void RunNumberCount (ref short nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount (ICollection<short> nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				sbyte count = 0;
				foreach (short i in nValue) {
					short t = i;
					this.RunNumberCount(ref t, nName, count);
					count++;
				}
				short value = 0;
				for (sbyte i = count; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
				}
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (short i in nValue) {
                    short t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}
		public void RunNumberSemi (ICollection<short> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				int count = 0;
				foreach (short i in nValue) {
					if (count > 0) {
						value += ":";
					} else {
						count++;
					}
					value += i;
				}
                this.RunNumber(ref value, nName);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (short i in nValue) {
                    short t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}

        public abstract void RunNumber(ref ushort nValue, string nName);
        public abstract void RunNumbers(ref ushort nValue, string nName);
        public void RunNumber(ICollection<ushort> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                foreach (ushort i in nValue) {
                    ushort t = i;
                    this.RunNumbers(ref t, nName);
                }
                this.PushArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
                foreach (ushort i in nValue) {
                    ushort t = i;
                    this.RunNumber(ref t, nName);
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
                sbyte count = 0;
                foreach (ushort i in nValue) {
                    ushort t = i;
                    this.RunNumberCount(ref t, nName, count);
                    count++;
                }
                ushort value = 0;
                for (sbyte i = count; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                }
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (ushort i in nValue) {
                    ushort t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }
        public void RunNumberSemi(ICollection<ushort> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                int count = 0;
                foreach (ushort i in nValue) {
                    if (count > 0) {
                        value += ":";
                    } else {
                        count++;
                    }
                    value += i;
                }
                this.RunNumber(ref value, nName);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (ushort i in nValue) {
                    ushort t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }

        public abstract void RunNumber(ref int nValue, string nName);
        public abstract void RunNumbers(ref int nValue, string nName);
        public void RunNumber (ICollection<int> nValue, string nNames, string nName)
		{
			if ( this.IsText() ) {
				this.PushArray(nNames);
				foreach (int i in nValue) {
                    int t = i;
                    this.RunNumbers (ref t, nName);
				}
                this.PopArray(nNames);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
				foreach (int i in nValue) {
                    int t = i;
                    this.RunNumber (ref t, nName);
				}
			}
		}
		public void RunNumberCount (ref int nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount (ICollection<int> nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				sbyte count = 0;
				foreach (int i in nValue) {
					int t = i;
					this.RunNumberCount(ref t, nName, count);
					count++;
				}
				int value = 0;
				for (sbyte i = count; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
				}
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (int i in nValue) {
                    int t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}
		public void RunNumberSemi (ICollection<int> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				int count = 0;
				foreach (int i in nValue) {
					if (count > 0) {
						value += ":";
					} else {
						count++;
					}
					value += i;
				}
                this.RunNumber(ref value, nName);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (int i in nValue) {
                    int t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}

        public abstract void RunNumber(ref uint nValue, string nName);
        public abstract void RunNumbers(ref uint nValue, string nName);
        public void RunNumber(ICollection<uint> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumbers(ref t, nName);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumber(ref t, nName);
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
                sbyte count = 0;
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumberCount(ref t, nName, count);
                    count++;
                }
                uint value = 0;
                for (sbyte i = count; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                }
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }
        public void RunNumberSemi(ICollection<uint> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                int count = 0;
                foreach (uint i in nValue) {
                    if (count > 0) {
                        value += ":";
                    } else {
                        count++;
                    }
                    value += i;
                }
                this.RunNumber(ref value, nName);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }

        public abstract void RunNumber(ref long nValue, string nName);
        public abstract void RunNumbers(ref long nValue, string nName);
        public void RunNumber (ICollection<long> nValue, string nNames, string nName)
		{
			if ( this.IsText() ) {
                this.PushArray(nNames);
				foreach (long i in nValue) {
                    long t = i;
                    this.RunNumbers (ref t, nName);
				}
				this.PopArray(nNames);
			} else {
				short count = (short)(nValue.Count);
				this.RunNumber(ref count, nNames);
				foreach (long i in nValue) {
                    long t = i;
					this.RunNumber (ref t, nName);
				}
			}
		}
		public void RunNumberCount (ref long nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount (ICollection<long> nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				sbyte count = 0;
				foreach (long i in nValue) {
					long t = i;
					this.RunNumberCount(ref t, nName, count);
					count++;
				}
				long value = 0;
				for (sbyte i = count; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
				}
			} else {
				short count = (short)(nValue.Count);
				this.RunNumber(ref count, nName);
				foreach (long i in nValue) {
                    long t = i;
					this.RunNumber(ref t, nName);
				}
			}
		}
		public void RunNumberSemi (ICollection<long> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				int count = 0;
				foreach (long i in nValue) {
					if (count > 0) {
						value += ":";
					} else {
						count++;
					}
					value += i;
				}
				this.RunNumber(ref value, nName);
			} else {
				short count = (short)(nValue.Count);
				this.RunNumber(ref count, nName);
				foreach (long i in nValue) {
                    long t = i;
					this.RunNumber(ref t, nName);
				}
			}
		}

        public abstract void RunNumber(ref ulong nValue, string nName);
        public abstract void RunNumbers(ref ulong nValue, string nName);
        public void RunNumber(ICollection<ulong> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunNumbers(ref t, nName);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunNumber(ref t, nName);
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
                sbyte count = 0;
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunNumberCount(ref t, nName, count);
                    count++;
                }
                ulong value = 0;
                for (sbyte i = count; i < nCount; ++i) {
                    this.RunNumberCount(ref value, nName, i);
                }
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }
        public void RunNumberSemi(ICollection<ulong> nValue, string nName)
        {
            if (this.IsText()) {
                string value = "";
                int count = 0;
                foreach (ulong i in nValue) {
                    if (count > 0) {
                        value += ":";
                    } else {
                        count++;
                    }
                    value += i;
                }
                this.RunNumber(ref value, nName);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }

        public abstract void RunNumber(ref float nValue, string nName);
        public abstract void RunNumbers(ref float nValue, string nName);
        public void RunNumber (ICollection<float> nValue, string nNames, string nName)
		{
			if ( this.IsText() ) {
                this.PushArray(nNames);
				foreach (float i in nValue) {
                    float t = i;
                    this.RunNumbers (ref t, nName);
				}
                this.PopArray(nNames);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
				foreach (float i in nValue) {
                    float t = i;
                    this.RunNumber (ref t, nName);
				}
			}
		}
		public void RunNumberCount (ref float nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount (ICollection<float> nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				sbyte count = 0;
				foreach (float i in nValue) {
					float t = i;
					this.RunNumberCount(ref t, nName, count);
					count++;
				}
				float value = 0f;
				for (sbyte i = count; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
				}
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (float i in nValue) {
                    float t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}
		public void RunNumberSemi (ICollection<float> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				int count = 0;
				foreach (float i in nValue) {
					if (count > 0) {
						value += ":";
					} else {
						count++;
					}
					value += i;
				}
                this.RunNumber(ref value, nName);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (float i in nValue) {
                    float t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}

        public abstract void RunNumber(ref double nValue, string nName);
        public abstract void RunNumbers(ref double nValue, string nName);
        public void RunNumber (ICollection<double> nValue, string nNames, string nName)
		{
			if ( this.IsText() ) {
                this.PushArray(nNames);
				foreach (double i in nValue) {
                    double t = i;
                    this.RunNumbers (ref t, nName);
				}
                this.PopArray(nNames);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
				foreach (double i in nValue) {
                    double t = i;
                    this.RunNumber (ref t, nName);
				}
			}
		}
		public void RunNumberCount (ref double nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount (ICollection<double> nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				sbyte count = 0;
				foreach (double i in nValue) {
					double t = i;
					this.RunNumberCount(ref t, nName, count);
					count++;
				}
				double value = 0d;
				for (sbyte i = count; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
				}
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (double i in nValue) {
                    double t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}
		public void RunNumberSemi (ICollection<double> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				int count = 0;
				foreach (double i in nValue) {
					if (count > 0) {
						value += ":";
					} else {
						count++;
					}
					value += i;
				}
                this.RunNumber(ref value, nName);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (double i in nValue) {
                    double t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}

        public abstract void RunNumber(ref string nValue, string nName);
        public abstract void RunNumbers(ref string nValue, string nName);
        public void RunNumber (ICollection<string> nValue, string nNames, string nName)
		{
			if ( this.IsText() ) {
                this.PushArray(nNames);
				foreach (string i in nValue) {
                    string t = i;
                    this.RunNumbers (ref t, nName);
				}
                this.PopArray(nNames);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
				foreach (string i in nValue) {
                    string t = i;
                    this.RunNumber (ref t, nName);
				}
			}
		}
		public void RunNumberCount (ref string nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				nName += "_"; nName += nCount;
                this.RunNumber(ref nValue, nName);
			} else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunNumberCount (ICollection<string> nValue, string nName, sbyte nCount)
		{
			if ( this.IsText() ) {
				sbyte count = 0;
				foreach (string i in nValue) {
					string t = i;
					this.RunNumberCount(ref t, nName, count);
					count++;
				}
				string value = "";
				for (sbyte i = count; i < nCount; ++i) {
					this.RunNumberCount(ref value, nName, i);
				}
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (string i in nValue) {
                    string t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}
		public void RunNumberSemi (ICollection<string> nValue, string nName)
		{
			if (this.IsText()) {
				string value = "";
				int count = 0;
				foreach (string i in nValue) {
					if (count > 0) {
						value += ":";
					} else {
						count++;
					}
					value += i;
				}
                this.RunNumber(ref value, nName);
			} else {
				short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
				foreach (string i in nValue) {
                    string t = i;
                    this.RunNumber(ref t, nName);
				}
			}
		}

        public void RunCrc32(ref uint nValue, string nName)
		{
			if ( this.IsText() ) {
                LogEngine logEngine = Singleton<LogEngine>.Instance();
                logEngine.LogError(TAG, "RunCrc32", nName);
            } else {
                this.RunNumber(ref nValue, nName);
			}
		}
		public void RunCrc32(ICollection<uint> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                LogEngine logEngine = Singleton<LogEngine>.Instance();
				logEngine.LogError(TAG, "RunCrc32", nNames, nName);
            } else {
                short count = (short)(nValue.Count);
				this.RunNumber(ref count, nNames);
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }
        public void RunCrc32Count(ref UInt32 nValue, string nName, sbyte nCount)
		{
			if (this.IsText()) {
                LogEngine logEngine = Singleton<LogEngine>.Instance();
                logEngine.LogError(TAG, "RunCrc32Count", nName, nCount);
            } else {
                this.RunNumber(ref nValue, nName);
			}
		}
        public void RunCrc32Count(ICollection<uint> nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                LogEngine logEngine = Singleton<LogEngine>.Instance();
                logEngine.LogError(TAG, "RunCrc32sCount", nName, nCount);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }
        public void RunCrc32Semi(ICollection<uint> nValue, string nName)
        {
            if (this.IsText()) {
                LogEngine logEngine = Singleton<LogEngine>.Instance();
                logEngine.LogError(TAG, "RunCrc32sCount", nName);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (uint i in nValue) {
                    uint t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }

        public abstract void RunTime(ref ulong nValue, string nName);
        public abstract void RunTimes(ref ulong nValue, string nName);
        public void RunTime(ICollection<ulong> nValue, string nNames, string nName)
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunTimes(ref t, nName);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nNames);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunNumber(ref t, nName);
                }
            }
        }
        public void RunTimeCount(ref ulong nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                LogEngine logEngine = Singleton<LogEngine>.Instance();
                logEngine.LogError(TAG, "RunTimeCount", nName, nCount);
            } else {
                this.RunTime(ref nValue, nName);
            }
        }
        public void RunTimeCount(ICollection<ulong> nValue, string nName, sbyte nCount)
        {
            if (this.IsText()) {
                sbyte count = 0;
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunTimeCount(ref t, nName, count);
                    count++;
                }
                ulong value = 0;
                for (sbyte i = count; i < nCount; ++i) {
                    this.RunTimeCount(ref value, nName, i);
                }
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunTime(ref t, nName);
                }
            }
        }
        public void RunTimeSemi(ICollection<ulong> nValue, string nName)
        {
            if (this.IsText()) {
                LogEngine logEngine = Singleton<LogEngine>.Instance();
                logEngine.LogError(TAG, "RunTimeSemi", nName);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (ulong i in nValue) {
                    ulong t = i;
                    this.RunTime(ref t, nName);
                }
            }
        }

		public void RunStream<T>(T nValue, string nName) where T : IStream, new()
        {
            if (this.IsText()) {
                this.PushClass(nName);
                nValue.Serialize(this, nName, 0);
                this.PopClass(nName);
            } else {
                nValue.Serialize(this, nName, 0);
            }
        }
		public void ChildStream<T>(T nValue, string nName) where T : IStream, new()
        {
            if (this.IsText()) {
                this.RunChild(nName);
                nValue.Serialize(this, nName, 0);
                this.RunNext(nName);
            } else {
                nValue.Serialize(this, nName, 0);
            }
        }
		public void RunStream<T>(ICollection<T> nValue, string nNames, string nName) where T : IStream, new()
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                foreach (T i in nValue) {
                    this.ChildStream(i, nName);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (T i in nValue) {
                    i.Serialize(this, nName, 0);
                }
            }
        }
		public void RunStream<T0, T1>(IDictionary<T0, T1> nValue, string nNames, string nName) where T1 : IMapStream, new()
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                foreach (KeyValuePair<T0, T1> i in nValue) {
                    this.ChildStream(i.Value, nName);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (KeyValuePair<T0, T1> i in nValue) {
                    i.Value.Serialize(this, nName, 0);
                }
            }
        }
		public void RunStreamCount<T>(T nValue, string nName, sbyte nCount) where T : IStream, new()
        {
            if (this.IsText()) {
                nName += "_"; nName += nCount;
                this.PushClass(nName);
                nValue.Serialize(this, nName, nCount);
                this.PopClass(nName);
            } else {
                nValue.Serialize(this, nName, 0);
            }
        }
		public void ChildStreamCount<T>(T nValue, string nName, sbyte nCount) where T : IStream, new()
        {
            if (this.IsText()) {
                nName += "_"; nName += nCount;
                this.RunChild(nName);
                nValue.Serialize(this, nName, nCount);
                this.RunNext(nName);
            } else {
                nValue.Serialize(this, nName, 0);
            }
        }
        public void RunStreamCount<T>(ICollection<T> nValue, string nNames, string nName, sbyte nCount) where T : IStream, new()
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                sbyte count = 0;
                foreach (T i in nValue) {
                    this.ChildStreamCount(i, nName, count);
                    count++;
                }
                T value = new T();
                for (sbyte i = count; i < nCount; ++i) {
                    this.ChildStreamCount(value, nName, i);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (T i in nValue) {
                    i.Serialize(this, nName, 0);
                }
            }
        }
        public void RunStreamCount<T0, T1>(IDictionary<T0, T1> nValue, string nNames, string nName, sbyte nCount) where T1 : IMapStream, new()
        {
            if (this.IsText()) {
                this.PushArray(nNames);
                sbyte count = 0;
                foreach (KeyValuePair<T0, T1> i in nValue) {
                    this.ChildStreamCount(i.Value, nName, count);
                    count++;
                }
                T1 value = new T1();
                for (sbyte i = count; i < nCount; ++i) {
                    this.ChildStreamCount(value, nName, i);
                }
                this.PopArray(nNames);
            } else {
                short count = (short)(nValue.Count);
                this.RunNumber(ref count, nName);
                foreach (KeyValuePair<T0, T1> i in nValue) {
                    i.Value.Serialize(this, nName, 0);
                }
            }
        }

        public abstract void RunBuffer(ref byte[] nValue, ref Int16 nLength);

        public abstract void PushStream(string nName);
        public abstract void PopStream(string nName);

        public abstract void PushClass(string nName);
        public abstract void PopClass(string nName);

        public abstract void PushArray(string nName);
        public abstract bool RunChild(string nName);
        public abstract bool RunNext(string nName);
        public abstract void PopArray(string nName);

        public abstract bool IsText();

        public virtual void SaveFile(string nName)
        {

        }

        public virtual string StringValue()
        {
            return "";
        }

        static readonly string TAG = typeof(Reader).Name;
    }
}

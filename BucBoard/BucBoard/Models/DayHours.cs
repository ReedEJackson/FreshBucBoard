using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucBoard.Models
{
    public class DayHours
    {
        public List<InOffice> DayTimes { get; set; }

        public DayHours()
        {
            DayTimes = new List<InOffice>();
            for (int i = 0; i < 5; i++)
            {
                DayTimes.Add(new InOffice());
            }
        }
        public DayHours(bool empty)
        {
            DayTimes = new List<InOffice>();
            if (!empty)
            {
                for (int i = 0; i < 5; i++)
                {
                    DayTimes.Add(new InOffice());
                }
            }
        }

        //Sinking Sort
        public void SortList()
        {
            bool sorted = false;
            int pass = 0;

            //Sort until finished or all passes completed
            while (!sorted && (pass < DayTimes.Count))
            {
                pass++;
                sorted = true;
                for (int i = 0; i < DayTimes.Count - pass; i++)
                {
                    //If out of order, swap values and
                    //set it to unsorted
                    if (DayTimes[i].StartHour > DayTimes[i + 1].StartHour)
                    {
                        SwapListValues(i, i + 1);
                        sorted = false;
                    }
                    else if (DayTimes[i].StartHour == DayTimes[i + 1].StartHour)
                    {
                        if (DayTimes[i].StartMin > DayTimes[i + 1].StartMin)
                        {
                            SwapListValues(i, i + 1);
                            sorted = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swaps two list values positions
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>a list with two int values int switched positions</returns>
        private void SwapListValues(int x, int y)
        {
            InOffice temp = DayTimes[x];
            DayTimes[x] = DayTimes[y];
            DayTimes[y] = temp;
        }

        //Checks if a time can be added
        public bool AddNewTime(InOffice newTime)
        {
            if (!DayTimes.Any())
            {
                DayTimes.Add(newTime);
                return true;
            }
            else
            {
                for (int i = 0; i < DayTimes.Count(); i++)
                {
                    if ((newTime.StartHour > DayTimes[i].StartHour &&
                        newTime.StartHour < DayTimes[i].EndHour) ||
                        (newTime.EndHour > DayTimes[i].StartHour &&
                        newTime.EndHour < DayTimes[i].EndHour))
                    {
                        return false;
                    }
                    else if (newTime.StartHour < DayTimes[i].StartHour &&
                            newTime.EndHour > DayTimes[i].EndHour)
                    {
                        return false;
                    }
                    else if (newTime.StartHour == DayTimes[i].StartHour ||
                        newTime.EndHour == DayTimes[i].EndHour)
                    {
                        if (DayTimes[i].StartHour == DayTimes[i].EndHour)
                        {
                            if (newTime.StartMin > DayTimes[i].StartMin ||
                                newTime.EndMin < DayTimes[i].EndMin)
                            {
                                return false;
                            }
                        }
                        else if ((newTime.StartHour == DayTimes[i].StartHour &&
                                newTime.StartMin > DayTimes[i].StartMin) ||
                                (newTime.EndHour == DayTimes[i].EndHour &&
                                newTime.EndMin < DayTimes[i].EndMin))
                        {
                            return false;
                        }
                    }
                }
                DayTimes.Add(newTime);
                return true;
            }
            
        }
    }
}
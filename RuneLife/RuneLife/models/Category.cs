using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneLife.models
{
    public class Category
    {
        public string Name { get; set; }
        public string OtherUnits { get; set; }
        public string ImageLocation { get; set; }
        public List<ProgressItem> ProgressItems { get; set; }
        public DateTime LastUpdated 
        {
            get
            {
                return ProgressItems.Count > 0 ? ProgressItems.Last().Date : new DateTime();
            } 
        }
        public string TotalOtherString
        {
            get
            {
                return TotalOther.ToString() + " " + OtherUnits;
            }
        }
        public double TotalTime
        {
            get
            {
                var totalProgressTime = 0.0;
                if (ProgressItems == null)
                    return 0;
                foreach (var item in ProgressItems)
                    totalProgressTime += item.Time;
                return totalProgressTime;
            }
        }
        public double TotalOther
        {
            get
            {
                var totalProgressOther = 0.0;
                if (ProgressItems == null)
                    return 0;
                foreach (var item in ProgressItems)
                    totalProgressOther += item.AdditionalInfo;
                return totalProgressOther;
            }
        }
        public string LevelString
        {
            get
            {
                return Level.ToString() + " / 99";
            }
        }
        public Bitmap Image
        {
            get
            {
                return ImageLocation == null || ImageLocation == ""
                    ? Properties.Resources.Logo
                    : new Bitmap(ImageLocation);
            }
        }
        public int Level
        {
            get
            {
                var total = 0.0;
                var timeToNextLevel = 1.0;
                var totalTime = TotalTime;
                for (int i = 1; i < 100; i++)
                {
                    timeToNextLevel *= 1.067302;
                    total += timeToNextLevel;
                    if (totalTime < total)
                        return i;
                }
                return 99;
            }
        }
        public Category copy()
        {
            var category = new Category();
            category.Name = this.Name;
            category.OtherUnits = this.OtherUnits;
            category.ImageLocation = this.ImageLocation;
            category.ProgressItems = new List<ProgressItem>();
            foreach (var item in this.ProgressItems)
                category.ProgressItems.Add(new ProgressItem
                {
                    Time = item.Time,
                    AdditionalInfo = item.AdditionalInfo,
                    Date = item.Date
                });
            return category;
        }
        public Category() { }
        public Category(string name, List<ProgressItem> progress)
        {
            this.Name = name;
            this.ProgressItems = progress;
        }
    }
}

using Core.Model.Abstract;
using Core.Model.Enum;

namespace Core.Model
{
    public class Analytics: Date
    {
        public TypeAnalytics TypeAnalytics { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

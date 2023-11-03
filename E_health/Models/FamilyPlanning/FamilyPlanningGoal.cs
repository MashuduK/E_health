namespace E_health.Models.FamilyPlanning
{
    public class FamilyPlanningGoal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DesiredNumberOfChildren { get; set; }
        public int DesiredSpacingBetweenChildren { get; set; }
        public int DesiredAgeAtFirstPregnancy { get; set; }
    }
}

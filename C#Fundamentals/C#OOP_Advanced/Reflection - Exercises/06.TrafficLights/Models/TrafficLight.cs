namespace _06.Traffic_Lights.Models
{
    using System;

    public class TrafficLight
    {
        public TrafficLight(LightColor colorState)
        {
            this.ColorState = colorState;
        }

        public LightColor ColorState { get; private set; }

        internal void UpdateState()
        {
            this.ColorState++;
            var colorStatesCount = Enum.GetNames(typeof(LightColor)).Length;
            this.ColorState = (LightColor)((int)this.ColorState % colorStatesCount);
        }
    }
}

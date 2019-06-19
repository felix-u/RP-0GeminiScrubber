using UnityEngine;

namespace RP0
{
    public class ContractGUI : UIBase
    {
        public const int MinPayload = 200;
        public const int MaxPayload = 10000;

        public static int CommsPayload = MinPayload;
        public static int WeatherPayload = MinPayload;

        private RP0Settings _settings;

        protected override void OnStart()
        {
            _settings = HighLogic.CurrentGame.Parameters.CustomParams<RP0Settings>();
            CommsPayload = _settings.CommsPayload;
            WeatherPayload = _settings.WeatherPayload;
        }

        public void ContractTab()
        {
            GUILayout.BeginVertical();
            try
            {
                GUILayout.Label($"Use this tab to set the required payload amount for contracts.", boldLabel);
                GUILayout.Space(10f);

                GUILayout.Label($"CommSat Payload amount: {CommsPayload}", HighLogic.Skin.label, GUILayout.Width(250));
                float commsAmnt = GUILayout.HorizontalSlider(CommsPayload, MinPayload, MaxPayload, HighLogic.Skin.horizontalSlider, HighLogic.Skin.horizontalSliderThumb);
                CommsPayload = Mathf.RoundToInt(commsAmnt / 100) * 100;    // slider works in increments of 100
                GUILayout.Space(5f);
                GUILayout.Label($"WeatherSat Payload amount: {WeatherPayload}", HighLogic.Skin.label, GUILayout.Width(250));
                float weatherAmnt = GUILayout.HorizontalSlider(WeatherPayload, MinPayload, MaxPayload, HighLogic.Skin.horizontalSlider, HighLogic.Skin.horizontalSliderThumb);
                WeatherPayload = Mathf.RoundToInt(weatherAmnt / 100) * 100;

                _settings.CommsPayload = CommsPayload;
                _settings.WeatherPayload = WeatherPayload;
            }
            finally
            {
                GUILayout.EndVertical();
            }
        }
    }
}

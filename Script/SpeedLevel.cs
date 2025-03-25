#nullable disable
public class SpeedLevel : LevelText
{
  private void Update() => this.TextSetting(GameMamager.instance.SpeedLevel);
}
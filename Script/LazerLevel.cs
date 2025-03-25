#nullable disable
public class LazerLevel : LevelText
{
  private void Update() => this.TextSetting(GameMamager.instance.LazerLevel);
}

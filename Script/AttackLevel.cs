public class AttackLevel : LevelText
{
  private void Update() => this.TextSetting(GameMamager.instance.AttackLevel);
}
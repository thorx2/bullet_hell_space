namespace BulletGame;

public partial class UIController : CanvasLayer
{

	[Signal] public delegate void StartGameNowEventHandler();

	[Export] private Control _mainMenuControl;
	[Export] private Control _settingsPanel;
	[Export] private Label _titleLabel;

	public void StartGameHit()
	{
		EmitSignal(SignalName.StartGameNow);
		_mainMenuControl.Visible = false;
		_titleLabel.Visible = false;
	}

	public void SettingsButtonsHit()
	{
		_settingsPanel.Visible = true;
		_mainMenuControl.Visible = false;
	}

	public void ExitGame()
	{
		GetTree().Quit();
	}
}

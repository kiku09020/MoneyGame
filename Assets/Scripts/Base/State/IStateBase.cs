using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateBase
{
	/// <summary>
	/// ‚»‚Ìó‘Ô‚É‚È‚Á‚½uŠÔ‚Ìˆ—
	/// </summary>
	public void StateEnter();

	/// <summary>
	/// ‚»‚Ìó‘Ô‚Ì‚Æ‚«–ˆƒtƒŒ[ƒ€ŒÄ‚Ño‚·ˆ—
	/// </summary>
	public void StateUpdate();

	/// <summary>
	/// ‚»‚Ìó‘Ô‚©‚ç”²‚¯‚éuŠÔ‚Ìˆ—
	/// </summary>
	public void StateExit();
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BerserkAdventure
{
    public class Timer
    {
        //DateTime zero = new DateTime();

        public bool EditTime()
        {
            if (Main.mainGame.timeTrapActivation > 0)
            {
                //Debug.Log("MainGame.mainGame.timeCompleteLevel - "+ MainGame.mainGame.timeCompleteLevel);
                Main.mainGame.timeTrapActivation -= Time.fixedDeltaTime / 3;
                return true;
            }
            if (Main.mainGame.timeTrapActivation < 0)
            {
                Main.mainGame.timerIsActive = false;
            }
            return false;
        }

		private DateTime _start;
		private float _elapsed = -1; //ןנמרוהרוו גנולÿ

		public TimeSpan Duration { get; private set; }

		public void Start(float elapsed)
		{
			_elapsed = elapsed;
			_start = DateTime.Now;
			Duration = TimeSpan.Zero;
		}

		public void Update()
		{
			if (_elapsed > 0)
			{
				Duration = DateTime.Now - _start;

				if (Duration.TotalSeconds > _elapsed)
				{
					_elapsed = 0;
				}
			}
			else if (_elapsed == 0)
			{
				_elapsed = -1;
			}
		}

		public bool IsEvent() => _elapsed == 0;

		public int TotalSeconds()
		{
			return (int)(_elapsed - Duration.TotalSeconds);
		}
	}
}

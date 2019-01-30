using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensit.TestSDK.Communication
{
	public enum Color
	{
		White,
		Red,
		Green,
		Blue
	}

	public class Team
	{
		public string Name { get; set; }
		public string NickName { get; set; }
		public Color ShirtColor { get; set; }
		public string HomeTown { get; set; }
		public string Ground { get; set; }
	}

	public class TeamBuilder
	{
		private string _name;
		private string _nickName;
		private Color _shirtColor;
		private string _hometown;
		private string _ground;

		public TeamBuilder CreateTeam(string name)
		{
			_name = name;
			return this;
		}

		public TeamBuilder WithNickName(string nickname)
		{
			_nickName = nickname;
			return this;
		}

		public TeamBuilder WithShirtColor(Color shirtColor)
		{
			_shirtColor = shirtColor;
			return this;
		}

		public TeamBuilder FromTown(string hometown)
		{
			_hometown = hometown;
			return this;
		}

		public TeamBuilder PlayingAt(string ground)
		{
			_ground = ground;
			return this;
		}

		public static implicit operator Team(TeamBuilder tb)
		{
			return new Team
			{
				Name = tb._name,
				NickName = tb._nickName,
				ShirtColor = tb._shirtColor,
				HomeTown = tb._hometown,
				Ground = tb._ground
			};
		}
	}

	public class Sample
	{
		public Sample()
		{
			TeamBuilder tb = new TeamBuilder();
			Team team2 = tb.CreateTeam("Real Madrid")
				.WithNickName("Los Merangues")
				.WithShirtColor(Color.White)
				.FromTown("Madrid")
				.PlayingAt("Santiago Bernabeu");
		}
	}
}

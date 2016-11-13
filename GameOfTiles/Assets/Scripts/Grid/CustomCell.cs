using UnityEngine;
using System.Collections;

namespace Gamelogic.Grids
{

	public class CustomCell : TileCell {
	
		public enum State {
			Empty,
			Player1,
			Player2,
			Player3,
			Player4,
			Player5,
			Player6
		};

		[SerializeField] State state;
		
		[SerializeField] private Sprite[] sprites = new Sprite[0];
		private Color color;
		private int frameIndex;
		private bool highlightOn;


		public State CellState {
			get {return state;}
			set {state = value;}
		}

		public bool HighlightOn { 			// TODO: Remove this if don't use later
			get { return highlightOn; }
			set	{ highlightOn = value; __UpdatePresentation(true); }
		}

		public override Color Color	{		// Currently used for debug, and has to be here because it is inherited.. or something..
			get { return color; }
			set	{ color = value; __UpdatePresentation(true); }
		}
		

		public int FrameIndex {				// Used as a sprite switcher for states
			get { return frameIndex; }
			set	{ frameIndex = value; __UpdatePresentation(true); }
		}


		public void SetPosition (Vector3 _worldPoint, float _angle) {	// used to set the position and rotation of a cell
			transform.localScale = Vector3.one;
			transform.localPosition = _worldPoint;
			SetAngle (_angle);
		}

		public override void SetAngle(float angle) {					// sets an angle on the X axis
			SpriteRenderer.transform.SetLocalRotationX(angle);
		}
		
		public override Vector2 Dimensions {							// returns the dimensions of the sprite for use in the grid builder
			get { return SpriteRenderer.sprite.bounds.size; }
		}

		public void Awake()	{
			highlightOn = false;
		}

		public override void __UpdatePresentation(bool forceUpdate) {	// this is used as a grid updater to avoid unnecessary changes
			//for now, always update, regardless of forceUpdate value
			if (frameIndex < sprites.Length)
				SpriteRenderer.sprite = sprites[frameIndex];

			SpriteRenderer.color = highlightOn ? Color.Lerp(color, Color.white, 0.8f) : color;	// will fade the color currently applied to the sprite closer to white
		}

		protected SpriteRenderer SpriteRenderer	{		// this is something to do with setting the sprite, removing will throw an error as it is inherited?
			get	{
				SpriteRenderer sprite = transform.FindChild("Sprite").GetComponent<SpriteRenderer>();
				
				if (sprite == null)
					Debug.LogError("The cell needs a child with a SpriteRenderer component attached");
				
				return sprite;
			}
		}

		public override void AddAngle (float angle) {	// only here as it is inherited so cant remove
		}
	}
}

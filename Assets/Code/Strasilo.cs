using UnityEngine;

public class Strasilo : MonoBehaviour, ITakeDamage, IPlayerRespawnListener
    {

        public GameObject DestroyedEffect;
        public int PointsToGivePlayer;
        public int MaxHealth = 3;

        public int Health { get; private set; }

        private Vector2 _startPosition;

    public void Start()
        {
            Health = MaxHealth;
            _startPosition = transform.position;
        }

    public void TakeDamage(int damage, GameObject instigator)
    {
        Health--;
        if (Health < 1)
        {
            if (PointsToGivePlayer != 0)
            {
                var projectile = instigator.GetComponent<Projectile>();
                if (projectile != null && projectile.Owner.GetComponent<Player>() != null)
                {
                    GameManager.Instance.AddPoints(PointsToGivePlayer);
                    FloatingText.Show(string.Format("+{0}!", PointsToGivePlayer), "PointStarText", new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));
                }
            }

            Instantiate(DestroyedEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }

    }

    public void OnPlayerRespawnInThisCheckpoint(Checkpoint checkpoint, Player player)
    {
        Health = 3;
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = _startPosition;
        gameObject.SetActive(true);
    }
    }


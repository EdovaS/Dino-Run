using DinoRunGame.Managers.GameManager;
using DinoRunGame.Managers.SoundManager;
using UnityEngine;

namespace DinoRunGame.Core
{
    public class DinoMovement : MonoBehaviour
    {
        /* C# Naming Conventions that i used but the naming conventions can be changed according to the
         * company naming conventions practices.
         * 
         * For Private Variables simple small letter like = playerHealth
         * For [SerializeField] variables I use _ underscore = _playerHealth
         * For Public Variables I use first word capsLock = PlayerHealth;
         */
        
        #region ChacheVariables
        private Rigidbody2D rb;
        private Collider2D boxCollider;
        #endregion

        [SerializeField] private float _jumpSpeed;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private float _CheckRadius;
        [SerializeField] private Transform _groundCheck;

        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _playerDeathParticleEffect;

        [SerializeField] private GameObject _dinoStanding;
        [SerializeField] private GameObject _dinoCrouch;

        [SerializeField] private AudioClip _jumpSoundSFX;
        
        private bool isOnGround;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            isOnGround = Physics2D.OverlapCircle(_groundCheck.position, _CheckRadius, _whatIsGround);

            PcInput();
        }

        private void PcInput()
        {
            //Controls for Pc
            if (Input.GetKey(KeyCode.Space)) JumpBtnDown();
            if (Input.GetKeyDown(KeyCode.DownArrow)) CrouchTouchDown();
            if (Input.GetKeyUp(KeyCode.DownArrow)) CrouchTouchUp();
        }

        // Called by Ui Btn
        public void JumpBtnDown()
        {
            if (isOnGround)
            {
                rb.velocity = new Vector2(0, _jumpSpeed);
                SoundManager.Instance.PlaySound(_jumpSoundSFX);
            }
        }

        // Called by Ui Btn
        public void CrouchTouchUp()
        {
            _dinoStanding.SetActive(true);
            _dinoCrouch.SetActive(false);
            boxCollider.enabled = true;
        }

        // Called by Ui Btn
        public void CrouchTouchDown()
        {
            _dinoStanding.SetActive(false);
            _dinoCrouch.SetActive(true);
            boxCollider.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Obstacle"))
            {
                _gameManager.GameOver();
                Instantiate(_playerDeathParticleEffect, transform.position, Quaternion.identity);
                transform.gameObject.SetActive(false);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_groundCheck.position, _CheckRadius);
        }
    }
}

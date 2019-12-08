using System.Collections;
using UnityEngine;
using RPG.Saving;
using RPG.Stats;
using RPG.Core;
using UnityEngine.SceneManagement;
using RPG.SceneManagement;

namespace RPG.Resources
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints = 100f;

        bool isDead = false;

        private void Start()
        {
            healthPoints = GetComponent<BaseStats>().GetHealth();
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if(healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
            if (gameObject.tag == "Player")
            {
                StartCoroutine(Transition());
            }
            else
            {
                if(gameObject.tag == "Boss")
                {
                    StartCoroutine(EndTransition());
                }
            }
        }

        private IEnumerator Transition()
        {
            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(2);

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene(0);

            yield return fader.FadeIn(3);
        }

        private IEnumerator EndTransition()
        {
            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(2);

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene(2);

            yield return fader.FadeIn(3);
        }

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;

            if (healthPoints == 0)
            {
                Die();
            }
        }
    }
}
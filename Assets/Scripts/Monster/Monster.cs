using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Monster {
    public class Monster : MonoBehaviour {
        public GameObject player;
        public float detectPlayerDistance;
        public float atkDistance;
        //public AudioClip moveAudio;

        protected bool isMove;
        protected bool isAtk;
        protected bool isAtkToPlayer;
        protected Animator mAnimator;
        protected Vector3 moveDir;
        protected Rigidbody mRigidbody;
        protected NavMeshAgent mNavigation;
        protected AnimatorStateInfo mAnimatorState;
        private bool isAware;
        protected AudioSource audioController;
        protected void defaultStart() {
            this.isMove = false;
            this.isAtk = false;
            this.isAtkToPlayer = false;
            this.mAnimator = this.gameObject.GetComponent<Animator>();
            this.mRigidbody = this.gameObject.GetComponent<Rigidbody>();
            this.mNavigation = this.gameObject.GetComponent<NavMeshAgent>();
            //this.audioController = this.gameObject.GetComponent<AudioSource>();
            //this.audioController.volume = 0.5f;
            //this.mNavigation.SetDestination(this.player.transform.position);
            //this.mNavigation.isStopped = true;
        }

        protected void stateUpdate() {
            this.mNavigation.isStopped = this.mNavigation.remainingDistance > this.detectPlayerDistance || this.mNavigation.remainingDistance < this.atkDistance;
            this.mNavigation.SetDestination(this.player.transform.position);
            this.isMove = this.mNavigation.velocity.sqrMagnitude > 0.01;
            this.isAtk = this.atkDistance >= this.mNavigation.remainingDistance;
            if (this.isAtk) {
                this.isMove = false;
                // Get attack animation state
                this.mAnimatorState = this.mAnimator.GetCurrentAnimatorStateInfo(0);
            }
            /*if (this.isMove && !this.audioController.isPlaying) {
                this.audioController.loop = true;
                //this.audioController.clip = this.moveAudio;
                this.audioController.Play();
            }
            if (!this.isMove && this.audioController.clip.name == this.moveAudio.name) {
                this.audioController.loop = false;
                this.audioController.Stop();
            }*/
            this.mAnimator.SetBool("isMove", this.isMove);
            this.mAnimator.SetBool("isAtk", this.isAtk);

        }
    }
}
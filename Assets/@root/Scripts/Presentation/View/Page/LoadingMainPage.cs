using System.Collections;
using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    public class LoadingMainPage : Page
    {
        [SerializeField] AudioSource _audioSourceWillPushEnter;

        // public override IEnumerator Initialize()
        // {
        //     Debug.Log("Initialize@LoadingMainPage");
        //     _audioSourceWillPushEnter.PlayOneShot(_audioSourceWillPushEnter.clip);
        //     yield return new WaitUntil(() => !_audioSourceWillPushEnter.isPlaying);
        // }

        public override IEnumerator WillPushEnter()
        {
            Debug.Log("WillPushEnter@LoadingMainPage");
            _audioSourceWillPushEnter.PlayOneShot(_audioSourceWillPushEnter.clip);
            yield break;
        }

        public override void DidPushEnter()
        {
            Debug.Log("DidPushEnter@LoadingMainPage");
            PageContainer.Of(transform).Push(PageConstants.MainPagePrefab, false, false);
        }

        // public override IEnumerator WillPushExit()
        // {
        //     Debug.Log("WillPushExit@LoadingMainPage");
        //     yield break;
        // }
        //
        // public override void DidPushExit()
        // {
        //     Debug.Log("DidPushExit@LoadingMainPage");
        // }

        // /// <summary>
        // /// スタックされていないので呼ばれない
        // /// </summary>
        // /// <returns></returns>
        // public override IEnumerator WillPopEnter()
        // {
        //     Debug.Log("WillPopEnter@LoadingMainPage");
        //     yield break;
        // }
        //
        // /// <summary>
        // /// スタックされていないので呼ばれない
        // /// </summary>
        // /// <returns></returns>
        // public override void DidPopEnter()
        // {
        //     Debug.Log("DidPopEnter@LoadingMainPage");
        // }
        //
        // /// <summary>
        // /// スタックされていないので呼ばれない
        // /// </summary>
        // /// <returns></returns>
        // public override IEnumerator WillPopExit()
        // {
        //     Debug.Log("DidPopEnter@LoadingMainPage");
        //     yield break;
        // }
        //
        // /// <summary>
        // /// スタックされていないので呼ばれない
        // /// </summary>
        // /// <returns></returns>
        // public override void DidPopExit()
        // {
        //     Debug.Log("DidPopExit@LoadingMainPage");
        // }
        //
        // public override IEnumerator Cleanup()
        // {
        //     Debug.Log("Cleanup@LoadingMainPage");
        //     yield break;
        // }
    }
}
using System.Collections;
using Cysharp.Threading.Tasks;
using Deniverse.UnityScreenNavigatorExercise.Application.Constant;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Sheet;
using UnityScreenNavigator.Runtime.Foundation.Coroutine;

namespace Deniverse.UnityScreenNavigatorExercise.Presentation.View
{
    /// <summary>
    /// メインページ
    /// </summary>
    public sealed class MainPage : Page
    {
        [SerializeField] Button _button_EnterResult;
        [SerializeField] Button _button_ReturnTitle;

        [SerializeField] SheetContainer _sheetContainer;
        [SerializeField] Button _button_Prev;
        [SerializeField] Button _button_Next;
        [SerializeField] AudioSource _audioSourcePressedPagenation;

        PageContainer _titlePageContainer;
        const int ItemSheetCount = 2;
        readonly int[] _sheetIds = new int[ItemSheetCount];
        int _currentSheetIndex;

        // UniTask → Coroutine 変換の動作確認
        public override IEnumerator Initialize() => UniTask.ToCoroutine(async () =>
        {
            var registerHandles = new AsyncProcessHandle[ItemSheetCount];
            for (var i = 0; i < ItemSheetCount; i++)
            {
                var index = i;
                registerHandles[i] = _sheetContainer.Register(SheetConstants.SheetSamplePrefab, x =>
                {
                    var id = x.sheetId;
                    _sheetIds[index] = id;
                    var shopItemGrid = (SampleSheet)x.instance;
                    shopItemGrid.Setup(index);
                });
                // AsyncProcessHandle の処理が完了するまで待つ
                await registerHandles[i];
            }

            _currentSheetIndex = 0;
            await _sheetContainer.Show(_sheetIds[_currentSheetIndex], false);

            _titlePageContainer = PageContainer.Find(PageContainerConstants.ExerciseScenePageContainerName);

            _button_Prev
                .OnClickAsObservable()
                .Where(_ => !_sheetContainer.IsInTransition)
                .Subscribe(_ => OnPrevButtonClicked())
                .AddTo(this);

            _button_Next
                .OnClickAsObservable()
                .Where(_ => !_sheetContainer.IsInTransition)
                .Subscribe(_ => OnNextButtonClicked())
                .AddTo(this);

            _button_EnterResult
                .OnClickAsObservable()
                .Subscribe(_ => OnEnterResultButtonClicked())
                .AddTo(this);

            _button_ReturnTitle
                .OnClickAsObservable()
                .Subscribe(_ => OnReturnTitleButtonClicked())
                .AddTo(this);
        });

        void OnPrevButtonClicked()
        {
            _audioSourcePressedPagenation.PlayOneShot(_audioSourcePressedPagenation.clip);

            // 下限に達した場合は下限に留まり，SheetContainer.Showメソッドを実行させない
            if (_currentSheetIndex <= 0)
            {
                _currentSheetIndex = 0;
                return;
            }

            _currentSheetIndex--;
            _sheetContainer.Show(_sheetIds[_currentSheetIndex], true);
        }

        void OnNextButtonClicked()
        {
            _audioSourcePressedPagenation.PlayOneShot(_audioSourcePressedPagenation.clip);

            // 上限に達した場合は上限に留まり，SheetContainer.Showメソッドを実行させない
            if (_currentSheetIndex >= _sheetIds.Length - 1)
            {
                _currentSheetIndex = _sheetIds.Length - 1;
                return;
            }

            _currentSheetIndex++;
            _sheetContainer.Show(_sheetIds[_currentSheetIndex], true);
        }

        void OnEnterResultButtonClicked()
        {
            _titlePageContainer.Push(PageConstants.ResultPagePrefab, false, false);
        }

        void OnReturnTitleButtonClicked()
        {
            _titlePageContainer.Pop(false);
        }

        public override IEnumerator WillPopEnter()
        {
            Debug.Log("WillPopEnter@MainPage");
            yield break;
        }
    }
}
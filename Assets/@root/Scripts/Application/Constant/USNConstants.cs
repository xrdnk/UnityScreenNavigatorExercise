using System;

namespace Deniverse.UnityScreenNavigatorExercise.Application.Constant
{
    /// <summary>
    /// ページ定数
    /// </summary>
    public static class PageConstants
    {
        const string PrefabFormat = "Prefabs/{0}";
        const string TitlePagePrefabName = "Page_Title";
        const string MainPagePrefabName = "Page_Main";
        const string LoadingMainPagePrefabName = "Page_LoadingMain";
        const string ResultPagePrefabName = "Page_Result";

        public static string TitlePagePrefab => string.Format(PrefabFormat, TitlePagePrefabName);
        public static string MainPagePrefab => string.Format(PrefabFormat, MainPagePrefabName);
        public static string LoadingMainPagePrefab => string.Format(PrefabFormat, LoadingMainPagePrefabName);
        public static string ResultPagePrefab => string.Format(PrefabFormat, ResultPagePrefabName);
    }

    /// <summary>
    /// ページコンテナ定数
    /// </summary>
    public static class PageContainerConstants
    {
        public static string ExerciseScenePageContainerName = "ExerciseScene_PageContainer";
    }

    /// <summary>
    /// モーダル定数
    /// </summary>
    public static class ModalConstants
    {
        const string PrefabFormat = "Prefabs/{0}";
        const string LicenceModalPrefabName = "Modal_Licence";

        public static string LicenceModalPrefab => string.Format(PrefabFormat, LicenceModalPrefabName);
    }

    /// <summary>
    /// モーダルコンテナ定数
    /// </summary>
    public static class ModalContainerConstants
    {
        public static string ExerciseSceneModalContainerName = "ExerciseScene_ModalContainer";
    }

    /// <summary>
    /// シート定数
    /// </summary>
    public static class SheetConstants
    {
        const string PrefabFormat = "Prefabs/{0}";
        const string SheetSamplePrefabName = "Sheet_Sample";

        public static string SheetSamplePrefab => string.Format(PrefabFormat, SheetSamplePrefabName);
    }

    public static class SheetContainerConstants
    {
        public static string MainPageSheetContainerName = "Main_Page_SheetContainer";
    }
}
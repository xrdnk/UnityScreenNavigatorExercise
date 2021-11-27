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
        const string LoadingPagePrefabName = "Page_Loading";
        const string ResultPagePrefabName = "Page_Result";

        public static string TitlePagePrefab() => string.Format(PrefabFormat, TitlePagePrefabName);
        public static string MainPagePrefab() => string.Format(PrefabFormat, MainPagePrefabName);
        public static string LoadingPagePrefab() => string.Format(PrefabFormat, LoadingPagePrefabName);
        public static string ResultPagePrefab() => string.Format(PrefabFormat, ResultPagePrefabName);
    }

    /// <summary>
    /// ページコンテナ定数
    /// </summary>
    public static class PageContainerConstants
    {
        public static string ExerciseScenePageContainerName = "ExerciseScene_PageContainer";
    }
}
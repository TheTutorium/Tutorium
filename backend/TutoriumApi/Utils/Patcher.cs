namespace tutorium.Utils
{
    public static class Patcher
    {
        public static void Patch<T, U>(T model, U patch)
        {
            var modelType = model!.GetType();
            var patchType = patch!.GetType();
            foreach (var patchProperty in patchType.GetProperties())
            {
                if (patchProperty.GetValue(patch) == null)
                {
                    continue;
                }
                var modelProperty = modelType.GetProperty(patchProperty.Name);
                modelProperty!.SetValue(model, patchProperty.GetValue(patch));
            }
        }
    }
}

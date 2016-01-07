using UnityEditor;

public class ModelTypeChangeV3 : AssetPostprocessor {

	public void OnPreprocessModel()
	{
		ModelImporter modelImporte = (ModelImporter)assetImporter;
		modelImporte.animationType = ModelImporterAnimationType.Legacy;
	}
}

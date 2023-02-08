import image_similarity_measures
from image_similarity_measures.quality_metrics import rmse, psnr
from image_similarity_measures.evaluate import evaluation

evaluation(org_img_path="example/lafayette_org.tif", 
           pred_img_path="example/lafayette_pred.tif", 
           metrics=["rmse", "psnr"])
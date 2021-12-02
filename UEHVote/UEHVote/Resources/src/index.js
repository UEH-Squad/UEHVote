import { hookFileUploadEvent } from './common';
import homepage from './homepage';
import rankpage from './rankpage';
import detailVote from './detailvotepage'

export const ShowMess = () => homepage.showMess();
export const DescriptionCarousel = () => rankpage.descriptionCarousel();
export const DetailVoteCarousel = () => detailVote.detailVoteCarousel();
export const HookFileUploadEvent = (previewImg, fileUploadRefId, discardBtn, imgContainerId, originalSrc) => hookFileUploadEvent(previewImg, fileUploadRefId, discardBtn, imgContainerId, originalSrc);

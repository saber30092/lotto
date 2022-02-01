//axios基礎設定
import axios from './Axios.js'

// UserController 
export const SignUp = data => axios.post('/ArtRoute/SignUp', data).then(respone => { console.log('SignUp'); return respone; }).catch(error => error);
export const GetListOfCity = () => axios.get('/ArtRoute/GetListOfCity').then(respone => { console.log('GetListOfCity'); return respone; }).catch(error => error);
export const GetDistrictsByCity = data => axios.get('/ArtRoute/GetDistrictsByCity', { params: { cityID: data } }).then(respone => { console.log('GetDistrictsByCity'); return respone; }).catch(error => error);
export const GetListOfCompetitionItems = () => axios.get('/ArtRoute/GetListOfCompetitionItems').then(respone => { console.log('GetListOfCompetitionItems'); return respone; }).catch(error => error);
export const AcademicExperience = data => axios.post('/ArtRoute/AcademicExperience', data).then(respone => { console.log('AcademicExperience'); return respone; }).catch(error => error);
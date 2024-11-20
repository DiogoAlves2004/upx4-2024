export default interface LoginResponse {
  authenticated?: boolean;
  created: Date;
  expirationDate: Date;
  acessToken: string;
  userName: string;
  message: string;
}

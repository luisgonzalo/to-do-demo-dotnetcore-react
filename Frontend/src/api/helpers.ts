import { baseApiDev, baseApiProd } from './constants';

export const isDevelopmentMode = (): boolean => (
  process.env.NODE_ENV === 'development'
);

export const apiMethods = {
  DELETE: 'DELETE',
  GET: 'GET',
  HEAD: 'HEAD',
  OPTIONS: 'OPTIONS',
  PATCH: 'PATCH',
  POST: 'POST',
  PUT: 'PUT',
  CONNECT: 'CONNECT',
  TRACE: 'TRACE',
};

export const requestConfig: RequestInit = {
  headers: {
    'Content-Type': 'application/json',
    'Accept': 'application/json',
  },
  mode: 'cors',
  method: apiMethods.GET,
};

export const getApiURL = (endPoint: string): string => {
  return isDevelopmentMode() ?
    `${baseApiDev}${endPoint}` :
    `${baseApiProd}${endPoint}`;
};

export enum HttpStatusCode {
  OK = 200,
  CREATED = 201,
  ACCEPTED = 202,
  NO_CONTENT = 204,
  BAD_REQUEST = 400,
  UNAUTHORIZED = 401,
  FORBIDDEN = 403,
  NOT_FOUND = 404,
  METHOD_NOT_ALLOWED = 405,
  NOT_ACCEPTABLE = 406,
  REQUEST_TIMEOUT = 408,
  INTERNAL_SERVER_ERROR = 500
}

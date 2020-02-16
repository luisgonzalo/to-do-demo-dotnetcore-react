import { requestConfig, getApiURL, apiMethods } from './helpers';
import { apiRoutes, apiErrorMessages } from './constants';
import { TodoItem } from '../model/todoItem';

const getTodoItems = (): Promise<TodoItem[]> => {
  const request: RequestInit = {
    ...requestConfig,
  };

  const apiUrl = getApiURL(apiRoutes.todoList);

  return fetch(apiUrl, request)
    .then(response => {
      if (response.ok) {
        return response.json();
      }

      throw new Error(apiErrorMessages.errorLoadingTodoList);
    });
};

const addTodoItem = (item: TodoItem): Promise<boolean> => {
  const request: RequestInit = {
    ...requestConfig,
    method: apiMethods.POST,
    body: JSON.stringify(item),
  };

  const apiUrl = getApiURL(apiRoutes.todoList);

  return fetch(apiUrl, request)
    .then(response => {
      if (response.ok) {
        return true;
      }

      throw new Error(apiErrorMessages.errorAddingItem);
    })
};

const changeItemStatus = (item: TodoItem): Promise<boolean> => {
  const request: RequestInit = {
    ...requestConfig,
    method: apiMethods.PUT,
    body: JSON.stringify(item),
  };

  const apiUrl = getApiURL(apiRoutes.todoList);

  return fetch(apiUrl, request)
    .then(response => {
      if (response.ok) {
        return true;
      }

      throw new Error(apiErrorMessages.errorChangingItemStatus);
    })
};

export const todoListApi = {
  getTodoItems,
  addTodoItem,
  changeItemStatus,
};

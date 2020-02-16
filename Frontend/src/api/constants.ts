const apiPrefix = '/api';
export const apiRoutes = {
  todoList: `${apiPrefix}/Task`,  
};

export const baseApiDev = 'http://localhost:50454';
export const baseApiProd = 'https://www.adomain.com';

export const apiErrorMessages = {
  errorLoadingTodoList: 'Cannot load to-do items, please try again later',
  errorAddingItem: 'Cannot add to-do item, please try again later',
  errorChangingItemStatus: 'Cannot change to-do item status, please try again later',
};

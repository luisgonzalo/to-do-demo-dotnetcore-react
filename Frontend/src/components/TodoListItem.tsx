import React from 'react';
import { TodoItem } from "../model/todoItem";
import { ListItem, ListItemIcon, Checkbox, ListItemText } from '@material-ui/core';

interface Props {
  item: TodoItem;
  onCheckedChange(item: TodoItem): void;
}
export const TodoListItem = (props: Props) => {
const { item, onCheckedChange } = props;

  return (
    <ListItem button onClick={() => onCheckedChange(item)}>
      <ListItemIcon>
        <Checkbox
          edge="start"
          checked={item.isComplete}
          tabIndex={-1}
        />
      </ListItemIcon>
      <ListItemText primary={item.description} />
    </ListItem>
  );
};

import React from 'react';
import { todoItem } from "../model/todoItem";
import { ListItem, ListItemIcon, Checkbox, ListItemText } from '@material-ui/core';

interface Props {
  item: todoItem;
  onCheckedChange(item: todoItem): void;
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
